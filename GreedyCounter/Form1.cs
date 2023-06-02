using System.Collections.Concurrent;
using System.Text;

namespace GreedyCounter
{
    public partial class Form1 : Form
    {
        public string FileName = string.Empty;

        private long lastReadPosition = 0;

        OpenFileDialog dialog;

        System.Windows.Forms.Timer timer;

        string output;

        //Initialize the concurrent dictionary;
        ConcurrentDictionary<string, int> cDict = new ConcurrentDictionary<string, int>();

        //Initialize a stringbuilder
        StringBuilder sb = new StringBuilder();

        public Form1()
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);


            tbStatus.Text = "Select the log file.";
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
                //Filter = "txt files (*.txt)|*.txt",
                //FilterIndex = 2,
                RestoreDirectory = true,
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileName = dialog.FileName;
                lastReadPosition = new FileInfo(FileName).Length;
                tbChatlogPath.Text = FileName;

                // Create a CancellationTokenSource to allow cancellation of the monitoring operation
                var cts = new CancellationTokenSource();

                // Start the monitoring operation in a separate task
                Task.Run(async () => await MonitorFile(cts.Token), cts.Token);

                tbStatus.Text = "Monitoring...";
                timer.Start();
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
                //|| (input.Contains("smiles"))) //this last condition is to be removed. Serves for testing only
            {
                return input.Split(" ")[1];
                // Find the name
            }
            return string.Empty;
        }

        private void AppendTextToOutput(string text)
        {
            int value = 1;
            int currValue = 0;
            // Add the stuff to a concurrent dictionary. Make that re-render on the UI thread every second or so?
            // check if key exists
            if (!cDict.ContainsKey(text))
            //key does not exist
            {
                //add new key pair
                if (cDict.TryAdd(text, value)) ;
            }
            else
            //key already exists. update the value
            {
                //get the current value
                if (cDict.TryGetValue(text, out currValue))
                {
                    // +1 to the current value
                    if (cDict.TryUpdate(text, currValue + 1, currValue)) ;
                }
            }



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

        void timer_Tick(object sender, EventArgs e)
        {

            //updates the Output text box
            sb.Clear();
            sb.AppendLine("Greedy Count:");
            // Add the keypair to a string via stringbuilder
            foreach (KeyValuePair<string, int> kvp in cDict)
            {
                sb.AppendLine($"{kvp.Key} : {kvp.Value.ToString()}"); ;
            }
            tbOutput.Text = sb.ToString();
        }

        private async void btnCopytoClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbOutput.Text);
            tbStatus.Text = "Copied!";
            await Task.Delay(500);
            tbStatus.Text = "Monitoring...";
        }

        private async void btnResetCounter_Click(object sender, EventArgs e)
        {
            cDict.Clear();
            tbStatus.Text = "Counter was reset!";
            await Task.Delay(500);
            tbStatus.Text = "Monitoring...";
        }
    }
}