/* Task Description */
/*
* Create an object domElement, that has the following properties and methods:
  * use prototypal inheritance, without function constructors
  * method init() that gets the domElement type
    * i.e. `Object.create(domElement).init('div')`
  * property type that is the type of the domElement
    * a valid type is any non-empty string that contains only Latin letters and digits
  * property innerHTML of type string
    * gets the domElement, parsed as valid HTML
      * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
  * property content of type string
    * sets the content of the element
    * works only if there are no children
  * property attributes
    * each attribute has name and value
    * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
  * property children
    * each child is a domElement or a string
  * property parent
    * parent is a domElement
  * method appendChild(domElement / string)
    * appends to the end of children list
  * method addAttribute(name, value)
    * throw Error if type is not valid
  * method removeAttribute(attribute)
    * throw Error if attribute does not exist in the domElement
*/


/* Example

var meta = Object.create(domElement)
	.init('meta')
	.addAttribute('charset', 'utf-8');

var head = Object.create(domElement)
	.init('head')
	.appendChild(meta)

var div = Object.create(domElement)
	.init('div')
	.addAttribute('style', 'font-size: 42px');

div.content = 'Hello, world!';

var body = Object.create(domElement)
	.init('body')
	.appendChild(div)
	.addAttribute('id', 'cuki')
	.addAttribute('bgcolor', '#012345');

var root = Object.create(domElement)
	.init('html')
	.appendChild(head)
	.appendChild(body);

console.log(root.innerHTML);
Outputs:
<html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
*/


function solve() {
	var domElement = (function () {
		function isValidType(type) {
			if (typeof type !== 'string') {
				throw new Error('Type is not valid');
			}

			return /^[A-Z0-9]+$/i.test(type);
		}

		function isValidAttribute(attribute) {
			if (typeof attribute !== 'string') {
				throw new Error('Attribute is not valid');
			}

			return /^[A-Z0-9\-]+$/i.test(attribute);
		}

		function getAttributesToString(attributes) {
			var str = '',
				keys = [],
				i,
				len,
				currKey;

			for (var key in attributes) {
				keys.push(key);
			}

			keys.sort();


			for (i = 0, len = keys.length; i < len; i += 1) {
				currKey = keys[i];
				str += ' ' + currKey + '="' + attributes[currKey] + '"';
			}

			return str;
		}

		var domElement = Object.defineProperties({}, {
			init: {
				value: function (type) {
					this.type = type;
					this.content = '';
					this.parent;
					this.children = [];
					this.attributes = [];

					return this;
				}
			},
			appendChild: {
				value: function (child) {
					this.children.push(child);

					if (typeof child === 'object') {
						child.parent = this;
					}

					return this;
				}
			},
			addAttribute: {
				value: function (name, value) {
					if (!isValidAttribute(name)) {
						throw new Error('Invalid attribute');
					}

					this.attributes[name] = value;

					return this;

				}
			},
			removeAttribute: {
				value: function (attribute) {
					if (!isValidAttribute(attribute)) {
						throw new Error('Invalid attribute');
					}

					if (!this.attributes[attribute]) {
						throw new Error('No such attribute');
					}

					delete this.attributes[attribute];

					return this;
				}
			},
			'innerHTML': {
				get: function () {
					var inner,
						child,
						i,
						len;

					inner = '<' + this.type;
					inner += getAttributesToString(this.attributes) + '>';

					for (i = 0, len = this.children.length; i < len; i += 1) {
						child = this.children[i];

						if (typeof child === 'string') {
							inner += child;
						}
						else {
							inner += child.innerHTML;
						}
					}

					inner += this.content;
					inner += '</' + this.type + '>';
					return inner;
				}
			},
			'type': {
				get: function () {
					return this._type;
				},
				set: function (value) {
					if (!isValidType(value)) {
						throw new Error('Invalid type');
					}

					this._type = value;
				}
			},
			'content': {
				get: function () {
					if (this.children.length) {
						return '';
					}

					return this._content;
				},
				set: function (value) {
					this._content = value;
				}
			},
			'children': {
				get: function () {
					return this._children;
				},
				set: function (value) {
					this._children = value;
				}
			},
			'attributes': {
				get: function () {
					return this._attributes;
				},
				set: function (value) {
					this._attributes = value;
				}
			},
			'parent': {
				get: function () {
					return this._parent;
				},
				set: function (value) {
					this._parent = value;
				}
			}

		});
		return domElement;
	} ());
	return domElement;
}

module.exports = solve;
