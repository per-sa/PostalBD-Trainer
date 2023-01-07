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
                var healthPtr = swed.ReadPointer(moduleBase, 0x02BD7DF0);
                healthPtr = swed.ReadPointer(healthPtr, 0x1C);
                healthPtr = swed.ReadPointer(healthPtr, 0x98);
                healthPtr = swed.ReadPointer(healthPtr, 0x290);
                healthPtr = swed.ReadPointer(healthPtr, 0x18);
                healthPtr = swed.ReadPointer(healthPtr, 0xD8);


                swed.WriteBytes(healthPtr, 0xB0, BitConverter.GetBytes(9999));
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
    }
}