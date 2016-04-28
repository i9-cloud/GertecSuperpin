using System;
using System.IO.Ports;
using System.Threading;

namespace Gertec.Interop
{
	public class SuperPin
	{
		// Fields
		public SerialPort Comm { get; set; }= new SerialPort();

		private string fBuffer = "";
		private byte LastChar = 0;

		// Methods
		public SuperPin ()
		{
		}

		public SuperPin (string porta = "COM1")
		{
			Comm.PortName = porta;
		}

		private void Comm_DataReceived (object sender, SerialDataReceivedEventArgs e)
		{
			int bytesToRead = this.Comm.BytesToRead;
			byte[] buffer = new byte[bytesToRead];
			this.Comm.Read (buffer, 0, bytesToRead);
			for (short i = 0; i < bytesToRead; i = (short)(i + 1)) {
				if (buffer [i] == 0x2a) {
					this.PinBeep ();
					this.LastChar = 0x2a;
					this.fBuffer = "";
				} else {
					if ((this.LastChar == 13) || (this.LastChar == 0x2a)) {
						char ch = (char)buffer [i];
						this.fBuffer = ch.ToString ();
					} else {
						this.fBuffer = this.fBuffer + ((char)buffer [i]).ToString ();
					}
					if (buffer [i] == 13) {
						this.PinBeep ();
					}
					this.LastChar = buffer [i];
				}
			}
		}

		public void PinAbrePorta (string Porta = "COM1", string Company = "GERTEC", string Module = "SuperPin")
		{
			if (!this.Comm.IsOpen) {
				this.Comm.PortName = Porta;
				this.Comm.BaudRate = 0x2580;
				this.Comm.Parity = Parity.None;
				this.Comm.StopBits = StopBits.One;
				this.Comm.DataBits = 8;
				this.Comm.DataReceived += new SerialDataReceivedEventHandler (this.Comm_DataReceived);
				this.Comm.Open ();
				this.PinLimpaTela ();
				this.PinEscreveTexto (Company);
				this.PinEscreveTexto (Module);
				this.PinBeep ();
				Thread.Sleep (0x7d0);
				this.PinLimpaTela ();
			}
		}

		public void PinApagaCursor ()
		{
			if (this.Comm.IsOpen) {
				byte[] buffer = new byte[] { 0x13 };
				this.Comm.Write (buffer, 0, 1);
			}
		}

		public void PinAtivaCursor ()
		{
			if (this.Comm.IsOpen) {
				byte[] buffer = new byte[] { 0x11 };
				this.Comm.Write (buffer, 0, 1);
				buffer [0] = 0x15;
				this.Comm.Write (buffer, 0, 1);
			}
		}

		public void PinAtivaEcoTeclado ()
		{
			if (this.Comm.IsOpen) {
				byte[] buffer = new byte[] { 0x85 };
				this.Comm.Write (buffer, 0, 1);
			}
		}

		public void PinAtivaLeitora ()
		{
			if (this.Comm.IsOpen) {
				byte[] buffer = new byte[] { 0x80 };
				this.Comm.Write (buffer, 0, 1);
			}
		}

		public void PinAtivaTeclado ()
		{
			if (this.Comm.IsOpen) {
				byte[] buffer = new byte[] { 130 };
				this.Comm.Write (buffer, 0, 1);
			}
		}

		public void PinBeep ()
		{
			if (this.Comm.IsOpen) {
				byte[] buffer = new byte[] { 20 };
				this.Comm.Write (buffer, 0, 1);
			}
		}

		public void PinClearBuffer ()
		{
			this.fBuffer = "";
			this.LastChar = 0;
			this.Comm.DiscardInBuffer ();
			this.Comm.DiscardOutBuffer ();
		}

		public void PinDesativaEcoTeclado ()
		{
			if (this.Comm.IsOpen) {
				byte[] buffer = new byte[] { 0x86 };
				this.Comm.Write (buffer, 0, 1);
			}
		}

		public void PinDesativaLeitora ()
		{
			if (this.Comm.IsOpen) {
				byte[] buffer = new byte[] { 0x81 };
				this.Comm.Write (buffer, 0, 1);
			}
		}

		public void PinDesativaTeclado ()
		{
			if (this.Comm.IsOpen) {
				byte[] buffer = new byte[] { 0x83 };
				this.Comm.Write (buffer, 0, 1);
			}
		}

		public void PinEscreveTexto (string Texto)
		{
			if (this.Comm.IsOpen) {
				Texto = Texto + "                ";
				Texto = Texto.Substring (0, 0x10);
				this.Comm.Write (Texto);
			}
		}

		public void PinFechaPorta (string message = "*** OBRIGADO ***")
		{
			if (this.Comm.IsOpen) {
				this.PinLimpaTela ();
				this.PinEscreveTexto (message);
				this.PinBeep ();
				Thread.Sleep (0x3e8);
				this.PinLimpaTela ();
				this.Comm.Close ();
			}
		}

		public void PinLimpaTela ()
		{
			if (this.Comm.IsOpen) {
				byte[] buffer = new byte[] { 12 };
				this.Comm.Write (buffer, 0, 1);
			}
		}

		public void PinMovimentaCursor (int Linha, int Coluna)
		{
			if (this.Comm.IsOpen) {
				byte[] buffer = new byte[] { 0x84, Convert.ToByte (Linha), Convert.ToByte (Coluna) };
				this.Comm.Write (buffer, 0, 3);
			}
		}

		// Properties
		public string PinBuffer {
			get {
				return this.fBuffer;
			}
		}

		public byte PinCommand {
			get {
				return this.LastChar;
			}
		}

		private bool fCursorPiscante;

		public bool PinCursorPiscante {
			set {
				fCursorPiscante = value;
				if (fCursorPiscante) {
					if (this.Comm.IsOpen) {
						byte[] buffer = new byte[] { 0x12 };
						this.Comm.Write (buffer, 0, 1);
					}
				} else {
					if (this.Comm.IsOpen) {
						byte[] buffer = new byte[] { 0x15 };
						this.Comm.Write (buffer, 0, 1);
					}
				}
			}
			get {
				return fCursorPiscante;
			}
		}
	}
}
