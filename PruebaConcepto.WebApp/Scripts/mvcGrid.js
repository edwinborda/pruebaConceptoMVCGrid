document.addEventListener('DOMContentLoaded', () => {
    var grid = document.querySelector('.mvc-grid');
    const url = '/home/getPermission';
    const Http = new XMLHttpRequest();
    var btn_edit = document.querySelector('.btn_edit');
    var btn_asociate = document.querySelector('.btn_asociate');
    var list = null;
    /*register events handlers*/
    document.addEventListener('rowclick', rowclick_);
    btn_edit.addEventListener('click', buttonEditClick_);

    /*Events*/
    grid.addEventListener('reloadstart', function (e) {
        console.log('reloadStart');
    });

    // Triggered after grid stop loading
    grid.addEventListener('reloadend', function (e) {
        console.log('reloadEnd');
    });

    // Triggered after grid reload fails
    grid.addEventListener('reloadfail', function (e) {
        console.log('reloadfail');
    });
    function getPermissions(callback) {
        if (list) {
            callback(list);
            return;
        }
        Http.open("GET", url);
        Http.send();
        Http.onreadystatechange = () => {
            if (Http.status == 200 && Http.responseText) {
                var result = JSON.parse(Http.responseText);
                list = JSON.parse(result);
                callback(list);
            }
        }
    }
    function rowclick_(e) {
        var row = e.target;
        e.target.parentElement.querySelectorAll('tr').forEach((it) => {
            it.classList.remove('selected');
        });
        row.classList.toggle('selected');
        btn_edit.setAttribute('data-id', e.detail.data.id);
        getPermissions((result) => {
            if (!result)
                return;
            e.detail.data['is-editable'] === 'True' && result.find(p => p.Name === 'Actualiza usuario') ?
                btn_edit.classList.remove('hidden') : btn_edit.classList.add('hidden');

            result.find(p => p.Name === 'Asociar roles') ? btn_asociate.classList.remove('hidden') : btn_asociate.classList.add('hidden')

        })
    }
    function buttonEditClick_(e) {
        var data_id = e.currentTarget.attributes['data-id'].value;
        location.href = `/home/Editar/${data_id}`;
    };
});

