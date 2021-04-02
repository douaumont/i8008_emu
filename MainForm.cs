using System;
using System.Windows.Forms;
using System.Text;

namespace i8008_emu_GUI
{
    public partial class MainForm : Form
    {
        private byte currentMemoryPage = 1;
        private byte[] ports = new byte[32];
        i8008_emu.i8008_CPU CPU;

        public MainForm()
        {
            InitializeComponent();
            MainClock.Enabled = true;
            MainClock.Stop();
            MemoryRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
            MemoryRichTextBox.Enabled = false;

            double freq = 1.0 / (0.001 * MainClock.Interval);
            freq = Math.Round(freq);

            FrequencyLabel.Text = "Frequency: " + freq.ToString() + " Hz";
            CPU = new i8008_emu.i8008_CPU(this);
            for (int i = 0; i < ports.Length; i++)
            {
                ports[i] = 0;
            }

            string outputPortsString = "";
            for (int i = 8; i < ports.Length; i++)
            {
                outputPortsString += i.ToString() + ": " + ports[i].ToString();
                if (i != ports.Length - 1)
                {
                    outputPortsString += "\n";
                }
            }
            OutputPortsRichTextBox.Text = outputPortsString;

            for (int i = 0; i < 8; i++)
            {
                InputPortSelection.Items.Add(i);
            }
            InputPortSelection.SelectedIndex = 0;

            this.UpdateWindow(true);

            StopButton.Enabled = false;
        }

        public byte ReadFromPort(byte portNumber)
        {
            return ports[portNumber];
        }

        public void WriteToPort(byte portNumber, byte value)
        {
            ports[portNumber] = value;
            this.UpdateWindow(true);
        }

        private void UpdateWindow(bool updateAnyway = false) //updateAnyway flag is nessecary, because it reduces amount of updates while executing an instruction
        {
            if (CPU.Cycles == 0 || updateAnyway) 
            {
                StackRichTextBox.Text = CPU.GetStack();
                UpdateMemoryTextBox(CPU.GetMemoryPage(currentMemoryPage));
                PageNumberTextBox.Text = currentMemoryPage.ToString();
                RegistersRichTextBox.Text = CPU.GetRegisters();
                FlagsRichTextBox.Text = CPU.GetFalgs();
                DisassembledLabel.Text = "Disassembled: " + CPU.DisassembleCurrentOpcode();
                CyclesLabel.Text = "Cycles: " + CPU.Cycles.ToString();
                PC_Label.Text = "PC: 0x" + CPU.ProgramCounter.ToString("X4");
                SP_Label.Text = "SP: " + CPU.StackPointer.ToString();
                HaltedLabel.Text = "Halted: " + CPU.Halted.ToString();
                UpdateOutputPortsTextBox();
            }
        }

        private void UpdateOutputPortsTextBox()
        {
            StringBuilder outputPortsStr = new StringBuilder();

            outputPortsStr.AppendFormat("{0}: {1}", 8, ports[8]);
            for (int i = 9; i < ports.Length; i++)
            {
                outputPortsStr.Append("\n");
                outputPortsStr.AppendFormat("{0}: {1}", i, ports[i]);
            }

            OutputPortsRichTextBox.Text = outputPortsStr.ToString();
        }

        private void UpdateMemoryTextBox(byte[] memory)
        {
            StringBuilder memoryPage = new StringBuilder();
            memoryPage.Append("   ");

            for (int i = 0; i < 16; i++)
            {
                memoryPage.Append(string.Format("x{0, -2}", i.ToString("X")));
            }

            memoryPage.Append("\n");

            for (int i = 0; i < 16; i++)
            {
                memoryPage.AppendFormat("{0}x ", i.ToString("X"));
                for (int j = 0; j < 16; j++)
                {
                    memoryPage.AppendFormat("{0} ", memory[i * 16 + j].ToString("X2"));
                }
                memoryPage.Append("\n");
            }
            MemoryRichTextBox.Text = memoryPage.ToString();
        }

        private void NextMemoryPageButton_Click(object sender, EventArgs e)
        {
            if (currentMemoryPage < 56)
            {
                currentMemoryPage++;
                UpdateMemoryTextBox(CPU.GetMemoryPage(currentMemoryPage));
                PageNumberTextBox.Text = currentMemoryPage.ToString();
            }
        }

        private void PriviuosMemoryPageButton_Click(object sender, EventArgs e)
        {
            if (currentMemoryPage > 1)
            {
                currentMemoryPage--;
                UpdateMemoryTextBox(CPU.GetMemoryPage(currentMemoryPage));
                PageNumberTextBox.Text = currentMemoryPage.ToString();
            }
        }

        private void PageNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    currentMemoryPage = Byte.Parse(PageNumberTextBox.Text);
                }
                catch
                {
                    MessageBox.Show("The entered value is not number!", "Error");
                }
                try
                {
                    UpdateMemoryTextBox(CPU.GetMemoryPage(currentMemoryPage));
                }
                catch (Exception excep)
                {
                    currentMemoryPage = 1;
                    PageNumberTextBox.Text = currentMemoryPage.ToString();
                    MessageBox.Show(excep.Message, "Error");
                }
            }


        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadMemoryButton_Click(object sender, EventArgs e)
        {
            OpenInputBinaryFile.ShowDialog();
            if (!CPU.LoadMemoryFromFile(OpenInputBinaryFile.FileName))
            {
                MessageBox.Show("Input file cannot be opened!", "Error");
            }
            this.UpdateWindow(true);
        }

        private void MainClock_Tick(object sender, EventArgs e)
        {
            CPU.Cycle();
            CyclesLabel.Text = "Cycles: " + CPU.Cycles.ToString();
            this.UpdateWindow();
            if (CPU.Halted)
            {
                MainClock.Stop();
                MessageBox.Show("The processor has been stopped!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StopButton.Enabled = false;
                ResetButton.Enabled = true;
                StepButton.Enabled = true;
                RunButton.Enabled = true;
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            MainClock.Start();
            StopButton.Enabled = true;
            ResetButton.Enabled = false;
            StepButton.Enabled = false;
            RunButton.Enabled = false;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            MainClock.Stop();
            StopButton.Enabled = false;
            ResetButton.Enabled = true;
            StepButton.Enabled = true;
            RunButton.Enabled = true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            CPU.Reset();
            this.UpdateWindow(true);

        }

        private void StepButton_Click(object sender, EventArgs e)
        {
            do
            {
                CPU.Cycle();
            } while (CPU.Cycles != 0);

            CPU.Cycle();

            this.UpdateWindow(true);
        }

        private void HaltedLabel_TextChanged(object sender, EventArgs e)
        {
            if (CPU.Halted == true)
            {
                HaltedLabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                HaltedLabel.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void ResetMemoryButton_Click(object sender, EventArgs e)
        {
            CPU.ResetMemory();
            this.UpdateWindow(true);
        }

        private void WriteToInputPortButton_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(InputValueForPort.Text);
            if (temp >= 0 && temp <= 255)
            {
                ports[InputPortSelection.SelectedIndex] = (byte)temp;
            }
            else
            {
                MessageBox.Show("The value for port must fit in 8 bits!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReadFromInputPortButton_Click(object sender, EventArgs e)
        {
            InputValueForPort.Text = ports[InputPortSelection.SelectedIndex].ToString();
        }

        private void InputValueForPort_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int temp = Convert.ToInt32(InputValueForPort.Text);
                if (temp >= 0 && temp <= 255)
                {
                    ports[InputPortSelection.SelectedIndex] = (byte)temp;
                }
                else
                {
                    MessageBox.Show("The value for port must fit in 8 bits!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ResetPortsButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ports.Length; i++)
            {
                ports[i] = 0;
            }
            this.UpdateWindow(true);
        }

        private void ResetEverythingButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ports.Length; i++)
            {
                ports[i] = 0;
            }
            CPU.ResetMemory();
            CPU.Reset();
            this.UpdateWindow(true);
        }

        private void FrequencyLabel_Click(object sender, EventArgs e)
        {
            DialogForm frequencyInput = new DialogForm("", "Enter the new frequency");
            int frequency;

            if (frequencyInput.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    frequency = int.Parse(frequencyInput.InputValue);
                    if (frequency > 0 && frequency <= 1000)
                    {
                        double interval = 1 / (double)frequency;
                        interval *= 1000.0;
                        MainClock.Interval = (int)Math.Round(interval);
                        FrequencyLabel.Text = "Frequency: " + frequency.ToString() + " Hz";
                    }
                    else
                    {
                        MessageBox.Show("The value must be in range from 1 to 1000 Hz!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
