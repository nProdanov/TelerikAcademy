function solve() {
    return function (fileContentsByName) {
        // you solution

        var $items = $($('.items').eq(0));
        var $fileContent = $('.file-content').eq(0);
        var $addBtn = $('.add-btn');
        var $input = $addBtn.next()
        .on('keyup',function(ev){
            debugger;
            var text = this.value;
            if(ev.keyCode === 13){
                var li = $('<li />')
                    .addClass('file-item')
                    .addClass('item');
                var anchor = $('<a />')
                    .addClass('item-name')
                    .html(text)
                    .appendTo(li);
                var anBtn = $('<a />')
                    .addClass('del-btn')
                    .appendTo(li);
                
                $items.append(li);
            }
        });

        $addBtn.on('click', function(){
            $input.addClass('visible');
            $(this).removeClass('visible');

        });


        
        $items.on('click', '.dir-item', function(){
            var $this = $(this);
            if ($this.hasClass('collapsed')){
                $this.removeClass('collapsed');
            }
            else{
                $this.addClass('collapsed');
            }
        });

        $items.on('click', '.file-item', function(){
            var $this = $(this);
            var textToShow = fileContentsByName[$this.find('.item-name').eq(0).html()] ;
            $fileContent.text(textToShow);
        });

        $items.on('click', '.del-btn', function(){
            var $this = $(this);
            $this.parent().remove();
        });

    };
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}