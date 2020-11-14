var count = 1;
  function readImage(input)
  {
    if(input.files && input.files[0])
    {
      var reader = new FileReader();
      var id = $(input).data("label");
      reader.onload = function(e) {
         $("#" + id).removeClass("admin-input-file");
         $("#" + id).addClass("admin-label-show-image");
         $("#" + id).html("<img src=" + e.target.result + " width='100%' height='100%'/>");
      }
      var idDiv = $(input).data("div");
      $("#" + id).removeAttr("for");
      reader.readAsDataURL(input.files[0]);
      count++;
      $('<div class="file" id="file-div-'+ count +'">' +
                    '<input type="file" id="file'+ count +'" name="files" style="display: none;" data-label="label-file-'+ count +'" data-div="file-div-'+ count +'" onchange="readImage(this)"/>' +
                    '<div class="admin-label-for-file">' +
                    '<label id="label-file-'+ count +'" for="file'+ count +'" class="admin-input-file admin-label-button-style"><i class="fa fa-plus"></i></label>'+
                    '<label class="admin-input-image-remove" id="button-remove-file-div-'+ count +'" data-div="file-div-'+ count +'" onclick="removeInput(this)">X</label>' +
                    '</div>'+
                    '</div>').insertAfter('#khunghinh .file:last');

    }
  }

  function removeInput(button)
  {
    var div = $(button).data("div");
    console.log(div);
    $("#" + div).remove();
  }