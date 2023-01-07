using Swed64;


namespace PostalBD_Trainer
{
    public partial class Form1 : Form
    {


        Swed swed;
        IntPtr moduleBase;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            swed = new Swed("POSTAL Brain Damaged");
            moduleBase = swed.GetModuleBase("GameAssembly.dll");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                swed.Nop(moduleBase, 0xBBF873, 4);
            }

            else
            {
                swed.WriteBytes(moduleBase, 0xBBF873, "89 4C C7 30");
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                // swed.Nop(moduleBase, 0x46A421, 5); // Share opcode with other entities

                // TO FIX: Pointers

                var healthPtr = swed.ReadPointer(moduleBase, 0x02C7CF98);

                healthPtr = swed.ReadPointer(healthPtr, 0xB8, 0x18, 0x290, 0x98);

                swed.WriteFloat(healthPtr, 0x1C, 99e3F);

                swed.Nop(moduleBase, 0x47BFE9, 5);

            }
            else
            {
                // swed.WriteBytes(moduleBase, 0x46A421, "F3 0F 11 41 1C");
                swed.WriteBytes(moduleBase, 0x47BFE9, "F3 0F 11 52 20");

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                swed.Nop(moduleBase, 0x652FA5, 5);
            }

            else
            {
                swed.WriteBytes(moduleBase, 0x652FA5, "F3 0F 11 7B 30");
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox1.Text == null)
            {
                textBox1.Text = 8.ToString();
            }

            var newSpeed = float.Parse(textBox1.Text);

            var speedAdd = swed.ReadPointer(moduleBase, 0x02C7CF98);

            speedAdd = swed.ReadPointer(speedAdd, 0xB8, 0x18, 0x248);

            if (checkBox4.Checked)
            {
                if (textBox1.Text != null)
                {
                    swed.WriteFloat(speedAdd, 0x30, newSpeed);

                }
            }

            else
            {
                swed.WriteFloat(speedAdd, 0x30, 8);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0 || textBox2.Text == null)
            {
                textBox2.Text = 0.75f.ToString();
            }

            var newHeight = float.Parse(textBox2.Text);

            var speedAdd = swed.ReadPointer(moduleBase, 0x02C7CF98);

            speedAdd = swed.ReadPointer(speedAdd, 0xB8, 0x18, 0x248);

            if (checkBox5.Checked)
            {
                if (textBox2.Text != null)
                {
                    swed.WriteFloat(speedAdd, 0x4C, newHeight);
                }

            }

            else
            {
                swed.WriteFloat(speedAdd, 0x4C, 0.75f);
            }
        }
    }
}