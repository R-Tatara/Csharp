namespace MvcArchitecture.Models
{
    public class MessageModel
    {
        public int Code { get; set; }

        public string Title { get; set; } = Constants.SoftwareName;

        public string Message { get; set; } = string.Empty;

        public MessageBoxButtons Button { get; set; }

        public MessageBoxIcon Icon { get; set; }
    }
}
