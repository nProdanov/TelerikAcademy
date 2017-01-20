/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {

  function validateTitle(title) {
    var i,
      len;

    if (typeof title !== 'string') {
      throw new Error('Title must be a string');
    }

    if (title.charAt(0) === ' ' || title.charAt(title.length - 1) === ' ') {
      throw new Error('Title must not start and end with a space');
    }

    if (!title.length) {
      throw new Error('Title must have at least one character');
    }

    if (/[\s]{2,}/.test(title)) {
      throw 'Invalid spacing.';
    }
  }

  function validatePresentations(presentations) {
    var currPresent,
      i,
      len;
    if (!Array.isArray(presentations)) {
      throw new Error('Presentations must be an array');
    }

    if (!presentations.length) {
      throw new Error('In presentations must have even one presentation');
    }

    for (i = 0, len = presentations.length; i < len; i += 1) {
      currPresent = presentations[i];

      validateTitle(currPresent);
    }
  }

  function validateName(name) {
    var names = [],
      firstName,
      lastName;

    if (typeof name !== 'string') {
      throw new Error('Name of students must be passed as a string');
    }

    names = name.split(' ');
    if (names.length !== 2) {
      throw new Error('Students must have exact two names separated by a single space');
    }

    names.forEach(function (n) {
      if (!/^[A-Z][a-z]*$/.test(n)) {
        throw new Error('Each name must contains only small letters, except the first.It must be a capital');
      }
    });

    firstName = names[0];
    lastName = names[1];

    return {
      firstname: firstName,
      lastname: lastName
    };
  }

  function validateID(id, max) {
    var min = 1;

    if (id != Number(id)) {
      throw 'Invalid type for id.';
    }

    id = +id;

    if (id < min || max < id) {
      throw new Error('Invalid ID');
    }
  }

  function validateResults(results, students) {
    var i,
      len,
      currRes,
      currStudID,
      currScore,
      j;

    if (!Array.isArray(results)) {
      throw new Error('Results must be an array');
    }

    if (results.length < 1) {
      throw new Error('Results must not be an empty array');
    }

    for (i = 0, len = results.length; i < len; i += 1) {
      currRes = results[i];
      currStudID = currRes.StudentID;
      currScore = currRes.score;

      validateID(currStudID, students.length);
      for (j = i + 1; j < len; j += 1) {
        if (currStudID === results[j].StudentID) {
          throw new Error(`Student with ID:${currStudID} appears more than once`);
        }
      }

      if (currScore === undefined) {
        throw new Error('Score must be passed');
      }

      if (currScore != Number(currScore)) {
        throw 'Invalid type for score.';
      }
    }
  }

  function generateStudent(name, students) {
    var stud = validateName(name);
    stud.id = students.length + 1;

    return stud;
  }

  var Course = {
    init: function (title, presentations) {
      this.title = title;
      this.presentations = presentations || [];
      this.students = [];

      return this;
    },
    addStudent: function (name) {
      var student = generateStudent(name, this.students);

      this.students.push(student);
      return student.id;
    },
    getAllStudents: function () {
      return this.students.slice();
    },
    submitHomework: function (studentID, homeworkID) {
      validateID(studentID, this.students.length);
      validateID(homeworkID, this.presentations.length);
    },
    pushExamResults: function (results) {
      validateResults(results, this.students);
    },
    getTopStudents: function () {
    }
  };

  Object.defineProperties(Course, {
    'title': {
      get: function () {
        return this._title;
      },
      set: function (value) {
        validateTitle(value);

        this._title = value;
      }
    },
    'presentations': {
      get: function () {
        return this._presentations;
      },
      set: function (value) {
        validatePresentations(value);

        this._presentations = value;
      }
    }
  });

  return Course;
}

module.exports = solve;
