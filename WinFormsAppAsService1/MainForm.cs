using Microsoft.Extensions.Options;

namespace WinFormsAppAsService1
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IDateService dateService;
        private readonly AppSettings settings;

        public MainForm(
            IServiceProvider serviceProvider,
            IDateService dateService,
            IOptions<AppSettings> settings)
        {
            InitializeComponent();

            this.serviceProvider = serviceProvider;
            this.dateService = dateService;
            this.settings = settings.Value;
        }
    }
}