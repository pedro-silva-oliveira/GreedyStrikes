using System.Windows.Forms;

namespace GreedyCounter
{
    public partial class Form1 : Form
    {
        public string FileName = string.Empty;

        private long lastReadPosition = 0;

        OpenFileDialog dialog;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectChatlog_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                InitialDirectory = @"C:\",
                Title = "Link Chatlog",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileName = dialog.FileName;
                lastReadPosition = new FileInfo(FileName).Length;
            }
        }

        private async Task MonitorFile(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // Check if the file has changed since the last read
                    if (new FileInfo(FileName).Length > lastReadPosition)
                    {
                        using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (StreamReader reader = new StreamReader(fs))
                            {
                                // Set the position to the last read position
                                fs.Seek(lastReadPosition, SeekOrigin.Begin);

                                // Read the new lines
                                while (!reader.EndOfStream)
                                {
                                    string line = await reader.ReadLineAsync();
                                    var striker = UserPerformedStrike(line);

                                    if (!string.IsNullOrEmpty(striker))
                                    {
                                        AppendTextToOutput(striker);
                                    }
                                }

                                // Update the last read position
                                lastReadPosition = fs.Position;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    AppendTextToOutput($"Error: {ex.Message}");
                }

                // Wait for a short period before checking again
                await Task.Delay(500);
            }
        }

        private string UserPerformedStrike(string input)
        {
            if ((input.Contains("delivers an overwhelming barrage against") && input.Contains(", causing some treasure to fall from their grip!"))
                || (input.Contains("swings a devious blow against") && input.Contains(", jarring some treasure loose!"))
                || (input.Contains("executes a masterful strike against ") && input.Contains(", who drops some treasure in surprise!"))
                || (input.Contains("performs a powerful attack against ") && input.Contains(", and steals some loot in the process!")))
            {
                return input.Split(" ")[0];
                // Find the name
            }
            return string.Empty;
        }

        private void AppendTextToOutput(string text)
        {
            // Add the stuff to a concurrent dictionary. Make that re-render on the UI thread every second or so?


            /*
            // Ensure the UI update is performed on the UI thread
            if (textBoxOutput.InvokeRequired)
            {
                textBoxOutput.Invoke(new Action<string>(AppendTextToOutput), text);
            }
            else
            {
                textBoxOutput.AppendText($"{text}{Environment.NewLine}");
            }*/
        }
    }
}