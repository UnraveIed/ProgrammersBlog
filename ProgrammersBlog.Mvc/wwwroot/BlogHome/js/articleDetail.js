$(document).ready(function () {
    $(function () {
        $(document).on('click', '#btn-save', function (event) {
            event.preventDefault();
            const form = $('#form-comment-add');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend)
                .done(function (data) {
                    const commentAddAjaxModel = jQuery.parseJSON(data);
                    console.log(commentAddAjaxModel);
                    const newFormBody = $('.form-card', commentAddAjaxModel.CommentAddPartial);
                    const cardBody = $('.form-card');
                    cardBody.replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        const newSingleComment = `
            <div class="media mb-4">
                <img class="d-flex mr-3 rounded-circle" src="https://randomuser.me/api/portraits/women/17.jpg" alt="">
                <div class="media-body">
                    <h5 class="mt-0">${commentAddAjaxModel.CommentDto.Comment.CreatedByName}</h5>
                    ${commentAddAjaxModel.CommentDto.Comment.Text}
                </div>
            </div>`;
                        const newSingleCommentObject = $(newSingleComment);
                        newSingleCommentObject.hide();
                        $('#comments').append(newSingleCommentObject);
                        newSingleCommentObject.fadeIn(3000);
                        toastr.success(`Sayın ${commentAddAjaxModel.CommentDto.Comment.CreatedByName} yorumunuz başarıyla eklenmiştir. Bir örneği sizler için karşınıza gelecek. Fakat; yorumunuz onaylandıktan sonra görünür olacaktır.`);
                        $('#btn-save').prop('disabled', true);
                        setTimeout(function () {
                            $('#btn-save').prop('disabled', false);
                        }, 15000);
                    } else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText += `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                });
        });
    }).fail(function (error) {
        console.error(error);
    });
});