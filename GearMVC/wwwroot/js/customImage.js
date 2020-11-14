CKEDITOR.editorConfig = function (config) {   
    config.removeDialogTabs = 'image:advanced;image:Link;link:advanced;link:upload';   
    config.filebrowserImageUploadUrl = '/admin/image'; //Action for Uploding image  
    config.extraPlugins = 'justify';
    config.filebrowserUploadMethod = 'xml';
    config.fileTools_requestHeaders = {
       'X-Requested-With': 'XMLHttpRequest'
    };
    config.height = 400;  
};