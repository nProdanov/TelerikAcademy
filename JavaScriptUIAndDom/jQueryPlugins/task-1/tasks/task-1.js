function solve() {
  return function (selector) {
    var $selectedEl = $(selector)
      .css('display', 'none');

    var $dropDownDiv = $('<div />')
      .addClass('dropdown-list');

    $selectedEl.parent().append($dropDownDiv);
    $dropDownDiv.append($selectedEl);

    var $divContainer = $('<div />')
      .addClass('options-container')
      .css({
        'position': 'absolute',
        'display': 'none'
      });

    var $divOption = $('<div />');
    $divOption.addClass('dropdown-item');
    var $selOptions = $selectedEl.children('option');
    for (var i = 0, len = $selOptions.length; i < len; i += 1) {
      var $currSelOption = $($selOptions[i]);
       var curSelOptionHtml = $currSelOption.html();
      var $currentDivOption = $divOption.clone(true)
      .attr('data-value', $currSelOption.val())
      .attr('data-index', i)
      .html(curSelOptionHtml)
      .appendTo($divContainer);
    }

    var $currDiv = $('<div />');
    $currDiv.addClass('current');
    $currDiv.html($($selOptions[0]).html());

    $currDiv.appendTo($dropDownDiv);
    $divContainer.appendTo($dropDownDiv);

    var lastCurrentDivText;
    $currDiv.on('click', function () {
      if ($divContainer.css('display') === 'block') {
        $divContainer.hide();
        $currDiv.html(lastCurrentDivText);
      }
      else {
        lastCurrentDivText = $currDiv.html();
        $currDiv.html('Select Value');
        $divContainer.show();
      }
    });

    $divContainer.on('click', '.dropdown-item', function () {
      var $this = $(this);
      $selectedEl.val($this.attr('data-value'));
      $currDiv.html($this.html());
      $divContainer.hide();
      lastCurrentDivText = $currDiv.html();
    });
  };
}

module.exports = solve;