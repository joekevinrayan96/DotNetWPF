using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Input;


namespace WPFPlayground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //const int INPUT_KEYBOARD = 1;
        //const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        //const uint KEYEVENTF_KEYUP = 0x0002;

        //[DllImport("user32.dll", SetLastError = true)]
        //static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        //[StructLayout(LayoutKind.Sequential)]
        //struct INPUT
        //{
        //    public int type;
        //    public InputUnion u;
        //}

        //[StructLayout(LayoutKind.Explicit)]
        //struct InputUnion
        //{
        //    [FieldOffset(0)]
        //    public KEYBDINPUT ki;
        //}

        //[StructLayout(LayoutKind.Sequential)]
        //struct KEYBDINPUT
        //{
        //    public ushort wVk;
        //    public ushort wScan;
        //    public uint dwFlags;
        //    public uint time;
        //    public IntPtr dwExtraInfo;
        //}


        public MainWindow()
        {
            InitializeComponent();

            Process noteProc = Process.Start("notepad.exe");

            Thread.Sleep(3000);

            string str = "HelloWorld";

            //char[] arr = str.ToCharArray();

            

            foreach (char c in str)
            {
                //Key key = (Key)Enum.Parse(typeof(Key), c);
                Key key = KeyInterop.KeyFromVirtualKey(c);
                SimulateKeyPress(key);
                //SimulateKeyWithModifiers(c, VirtualKeyModifiers.Control);
            }


            //System.Console.WriteLine("Letters Typed");

        }

        public static void SimulateKeyPress(Key key)
        {
            if(Keyboard.PrimaryDevice != null)
            {
                if(Keyboard.PrimaryDevice.ActiveSource != null)
                {
                    var e = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key)
                    {
                        RoutedEvent = Keyboard.KeyDownEvent
                    };

                    InputManager.Current.ProcessInput(e);
                }
            }
        }

        //static void SimulateKeyPress(char key)
        //{
        //    // Simulate pressing a key without modifiers
        //    byte keyCode = (byte)KeyInterop.VirtualKeyFromKey(KeyInterop.KeyFromVirtualKey(key));
        //    keybd_event(keyCode, 0, 0, 0);
        //    keybd_event(keyCode, 0, KEYEVENTF_KEYUP, 0);
        //}


        //static void SimulateKeyPress(char key)
        //{
        //    ushort keyCode = (ushort)key;
        //    INPUT[] inputs = new INPUT[2];

        //    // Key down
        //    inputs[0].type = INPUT_KEYBOARD;
        //    inputs[0].u.ki = new KEYBDINPUT
        //    {
        //        wVk = 0,
        //        wScan = keyCode,
        //        dwFlags = KEYEVENTF_EXTENDEDKEY,
        //        time = 0,
        //        dwExtraInfo = IntPtr.Zero
        //    };

        //    inputs[1].type = INPUT_KEYBOARD;
        //    inputs[1].u.ki = new KEYBDINPUT
        //    {
        //        wVk = 0,
        //        wScan = keyCode,
        //        dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
        //        time = 0,
        //        dwExtraInfo = IntPtr.Zero
        //    };

        //    uint result = SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        //    if (result == 0)
        //    {
        //        throw new Exception("Failed to send key input.");
        //    }
        //}


        //static void SimulateKeyWithModifiers(char key, VirtualKeyModifiers modifiers)
        //{
        //    // Simulate pressing a key with modifiers

        //    // Set the desired modifiers
        //    if (modifiers.HasFlag(VirtualKeyModifiers.Control))
        //        keybd_event((byte)KeyInterop.VirtualKeyFromKey(Key.LeftCtrl), 0, 0, 0);
        //    if (modifiers.HasFlag(VirtualKeyModifiers.Shift))
        //        keybd_event((byte)KeyInterop.VirtualKeyFromKey(Key.LeftShift), 0, 0, 0);
        //    if (modifiers.HasFlag(VirtualKeyModifiers.Menu))
        //        keybd_event((byte)KeyInterop.VirtualKeyFromKey(Key.LeftAlt), 0, 0, 0);

        //    SimulateKeyPress(key);

        //    // Release the modifiers
        //    if (modifiers.HasFlag(VirtualKeyModifiers.Control))
        //        keybd_event((byte)KeyInterop.VirtualKeyFromKey(Key.LeftCtrl), 0, KEYEVENTF_KEYUP, 0);
        //    if (modifiers.HasFlag(VirtualKeyModifiers.Shift))
        //        keybd_event((byte)KeyInterop.VirtualKeyFromKey(Key.LeftShift), 0, KEYEVENTF_KEYUP, 0);
        //    if (modifiers.HasFlag(VirtualKeyModifiers.Menu))
        //        keybd_event((byte)KeyInterop.VirtualKeyFromKey(Key.LeftAlt), 0, KEYEVENTF_KEYUP, 0);
        //}

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Hello {firstNameText.Text}");
            //MessageBox.Show("Hello " + firstNameText.Text);

            
        }
    }

    
}
