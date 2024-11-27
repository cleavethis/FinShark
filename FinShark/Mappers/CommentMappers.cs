using System.Runtime.CompilerServices;
using FinShark.Models;
using FinShark.Dtos;
using FinShark.Dtos.Comment;

namespace FinShark.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                commentID = commentModel.commentID,
                title = commentModel.title,
                content = commentModel.content,
                createdOn = commentModel.createdOn,
                stockId = commentModel.stockId
            };

        }

        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId)
        {
            return new Comment
            {

                title = commentDto.title,
                content = commentDto.content,
                stockId = stockId
            };

        }
    }
}
