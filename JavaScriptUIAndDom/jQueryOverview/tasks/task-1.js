function solve() {
  return function (selector, count) {
      if(count === undefined || count === null || typeof count === 'object' || Array.isArray(count)){
          throw {
              name: 'CountUndefinied',
              message: 'CountUndefinied'
          };
      }
      if (!(+count)){
          throw {
              name: 'InvalidFormatOfCount',
              message: 'InvalidFormatOfCount'
          };
      }

       count = +count;
      if (count < 1){
          throw {
              name: 'CountMustBeEqualOrGreaterThanZero',
              message: 'CountMustBeEqualOrGreaterThanZero'
          };
      }

      if (selector === undefined || selector === null || Array.isArray(selector)){
          throw {
              name : 'NotValidSelector',
              message: 'NotValidSelector'
          };
      }

   var $selectedEl = $(selector)[0];
   if($selectedEl === null){
       return;
   }
   
   var $ul = $('<ul />');
   $ul.addClass('items-list');
   var $li = $('<li />');
   $li.addClass('list-item');
   $li.text('List item #');

   for (var i = 0; i < count; i += 1) {
       var $currli = $li.clone(true);
       $currli.text($currli.text() + i);
       $currli.appendTo($ul);
   }

   $ul.appendTo($selectedEl);

  };
}

module.exports = solve;