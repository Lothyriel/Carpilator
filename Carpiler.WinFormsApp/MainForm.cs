using Domain.Carpiler;
using Domain.Carpiler.Languages;
using Domain.Carpiler.Syntatic.Constructs;
using Newtonsoft.Json;

namespace Carpiler.WinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly Language _language = new CCsharp();

        public List<Statement>? Ast { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            FocusSource();
        }

        private void Bt_Source_Click(object sender, EventArgs e)
        {
            FocusSource();
        }

        private void FocusSource()
        {
            Tb_SourceCode.Visible = true;
            Tb_Ast.Visible = false;
        }

        private void Bt_Ast_Click(object sender, EventArgs e)
        {
            Compile();

            Tb_Ast.Visible = true;
            Tb_SourceCode.Visible = false;

            if (Ast is null || Ast.Any() == false)
            {
                Tb_Ast.Text = "Not compiling";
                return;
            }

            Tb_Ast.Text = JsonConvert.SerializeObject(Ast, Formatting.Indented);
        }

        private void Tb_SourceCode_TextChanged(object sender, EventArgs e)
        {
            Compile();
        }

        private void Compile()
        {
            if (string.IsNullOrWhiteSpace(Tb_SourceCode.Text))
            {
                return;
            }

            Exception? exc = null;
            try
            {
                Ast = new Carpilator(Tb_SourceCode.Text, _language).Compile();
            }
            catch (Exception ex)
            {
                exc = ex;
            }

            Lb_Errors.Items.Clear();
            Lb_Errors.Items.Add(exc?.Message ?? "Compiled");
        }
    }
}