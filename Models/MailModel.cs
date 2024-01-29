namespace BackyardHibachi.Models
{
    public class LogicModel
    {
        public string Smtp { get; set; } = "sp-vm.serverpipe.org";
        public int Port { get; set; } = 587;
        public bool IsEnableSsl { get; set; } = true;
        public bool IsUseDefaultCredentials { get; set; }
        public string Login { get; set; } = "relay@serverpipe.org";
        public string Email { get; set; } = "relay@serverpipe.org";
        public string Password { get; set; } = "Z326050r@";
        public string FromName { get; set; } = "Backyard Hibachi";
        public string FromEmail { get; set; } = "relay@serverpipe.org";
        public string ToEmail { get; set; } = "nikitatkachuk6@gmail.com, hibachivegas247@gmail.com";
        public string? Subject { get; set; } = "Contact Us";
        public string? Body { get; set; }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Message { get; set; }
    }
}
