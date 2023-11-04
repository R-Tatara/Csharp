namespace MvcArchitecture.Models
{
    public class MessageTable
    {
        private readonly List<MessageModel> _messageList;

        public MessageTable()
        {
            _messageList = new List<MessageModel>
            {
                new MessageModel
                {
                    Code = 100,
                    Message = "Sample error. (Error Code: 100)",
                    Button = MessageBoxButtons.OK,
                    Icon = MessageBoxIcon.Warning
                }
            };
        }

        public MessageModel? GetMessageInfo(int errorCode)
        {
            return _messageList.Find(error => error.Code == errorCode);
        }
    }
}
