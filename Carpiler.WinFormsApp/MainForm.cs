using Domain.Carpiler;
using Domain.Carpiler.Languages;
using Newtonsoft.Json;

namespace Carpiler.WinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly Language _language = new CCsharp();
        public Carpilator? Carpilator { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            FocusSource();
        }

        private void FocusSource()
        {
            Tb_SourceCode.Visible = true;
            Tb_Ast.Visible = false;
        }

        private void TryCompile(Action compilation)
        {
            if (string.IsNullOrWhiteSpace(Tb_SourceCode.Text))
            {
                return;
            }

            try
            {
                Carpilator = new Carpilator(Tb_SourceCode.Text, _language);

                compilation();

                AddMessage("Compiled");
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
                return;
            }
        }

        private void AddMessage(string error)
        {
            Lb_Errors.Items.Clear();
            Lb_Errors.Items.Add(error);
        }

        private void Bt_Source_Click(object sender, EventArgs e)
        {
            FocusSource();
        }

        private void Bt_Ast_Click(object sender, EventArgs e)
        {
            TryCompile(() =>
            {
                Tb_Ast.Visible = true;
                Tb_SourceCode.Visible = false;

                var tokens = Carpilator!.Tokenize();
                var ast = Carpilator.Parse(tokens);

                if (ast is null || ast.Any() == false)
                {
                    Tb_Ast.Text = "Not compiling";
                    return;
                }

                Tb_Ast.Text = JsonConvert.SerializeObject(ast, Formatting.Indented);
            });
        }

        private void Tb_SourceCode_TextChanged(object sender, EventArgs e)
        {
            TryCompile(() => Carpilator?.Compile());
        }

        private void Bt_Tokens_Click(object sender, EventArgs e)
        {
            TryCompile(() =>
            {
                Tb_Ast.Visible = true;
                Tb_SourceCode.Visible = false;

                var tokens = Carpilator!.Tokenize();

                if (tokens.Any() == false)
                {
                    Tb_Ast.Text = "Not compiling";
                    return;
                }

                Tb_Ast.Text = string.Join(Environment.NewLine, tokens);
            });
        }
    }
}