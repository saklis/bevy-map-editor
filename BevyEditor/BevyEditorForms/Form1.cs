using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BevyEditorForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            TcpClient client = new TcpClient("localhost", 3333);
            byte[] data = Encoding.ASCII.GetBytes("Hello, Server!");

            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
            
            String responseData = String.Empty;
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);
        }
    }
}