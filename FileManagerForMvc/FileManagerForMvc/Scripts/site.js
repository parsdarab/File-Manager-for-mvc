


    function openDialog(url, Id, div) {
        if (typeof (Id) === 'number' || !Id) {

            $.ajax({
                url: url,
                type: "Get",
                data: { id: Id },

                statusCode: {

                    //ok
                    200: function (data) {
                        div.html(data);
                        div.dialog("open");
                    },

                }
            });


        } else {
            //debugger;
            //مهم ارسال جیسون به اکشن
            var r = JSON.parse(Id);
            //var result = $.param(r);
            //var json = $.toJSON(Id);
            $.ajax({
                url: url,
                type: "Get",
                //contentType: 'application/json; charset=utf-8',
                //data: { data: r },
                data: r,
                //data: JSON.stringify({
                //    data: result,
                //}),
                //data: JSON.stringify(jsonConcat(Id)),
                //data: JSON.parse(Id)
                //data: JSON.parse({ data: json }),
            }).done(function (result) {
                if (result.status == false) {
                    ShowMessage('warning', result.message, "خطا");
                } else {
                    div.html(result);
                    div.dialog("open");
                }
            });
        }
    }

    function CloseWindows(windowName) {
        $(windowName).closest('.ui-dialog-content').dialog('close');
    }
