using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace MultipleKeySender
{

	public partial class Form1 : Form
	{
		public class MessageFilter : IMessageFilter
		{
			Form1 form;
			public MessageFilter(Form1 form)
			{
				this.form = form;
			}
			public bool PreFilterMessage(ref Message m)
			{
				return form.PreFilterMessage(ref m);
			}
		}

		MessageFilter messageFilter;
		Win32dll.KeyboardHookDelegate hookDelegate;
		IntPtr hook;
		const int KeyboardHookType = 13;
		static readonly object EventKeyboardHooked = new object();

		public Form1()
		{
			InitializeComponent();

			// リソース
			cursorTarget = new Cursor(Properties.Resources.target1.Handle);
			this.Icon = Properties.Resources.app;

			// メッセージ受付
			messageFilter = new MessageFilter(this);
			Application.AddMessageFilter(messageFilter);

			// グローバルフック
			if (Environment.OSVersion.Platform != PlatformID.Win32NT)
				throw new PlatformNotSupportedException("Windows 98/Meではサポートされていません。");
			this.hookDelegate = new Win32dll.KeyboardHookDelegate(CallNextHook);
			IntPtr module = Marshal.GetHINSTANCE(typeof(Form1).Assembly.GetModules()[0]);
			hook = Win32dll.SetWindowsHookEx(KeyboardHookType, hookDelegate, module, 0);
			if (hook == IntPtr.Zero)
			{
				int errCode = Marshal.GetLastWin32Error();

				StringBuilder message = new StringBuilder(255);

				Win32dll.FormatMessage(
					Win32dll.FORMAT_MESSAGE_FROM_SYSTEM,
					IntPtr.Zero,
					(uint)errCode,
					0,
					message,
					message.Capacity,
					IntPtr.Zero
				);


				string msg = message.ToString();


			}
		}
		private int CallNextHook(int code, KeyboardMessage message, ref KeyboardState state)
		{
			if (code >= 0)
				OnKeyboardHooked(new Win32dll.KeyboardHookedEventArgs(message, ref state));
			return Win32dll.CallNextHookEx(hook, code, message, ref state);
		}
		///<summary>
		///KeyboardHookedイベントを発生させる。
		///</summary>
		///<param name="e">イベントのデータ。</param>
		protected virtual void OnKeyboardHooked(Win32dll.KeyboardHookedEventArgs e)
		{
			Win32dll.KeyboardHookedEventHandler handler = base.Events[EventKeyboardHooked] as Win32dll.KeyboardHookedEventHandler;
			if (handler != null)
				handler(this, e);
			// 処理
			// hogehogehoge
			edtInput.Text = "hoge";
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			// グローバルフック終了
			if(hook != IntPtr.Zero){
				Win32dll.UnhookWindowsHookEx(hook);
				hook = IntPtr.Zero;
			}

			// メッセージ受付終了
			Application.RemoveMessageFilter(messageFilter);
			messageFilter = null;
		}

		// リソース
		Cursor cursorTarget;

		// -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- //
		// キー送信
		// -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- //
		public bool PreFilterMessage(ref Message m)
		{
			if (m.HWnd == edtInput.Handle)
			{
				if (m.Msg == Win32dll.WM_KEYDOWN || m.Msg == Win32dll.WM_KEYUP)
				{
					foreach (WindowInfo win in windows)
					{
						if (win != null)
						{
							Win32dll.PostMessage(win.hwnd, m.Msg, m.WParam, m.LParam);
						}
					}
					return true;
				}
			}
			return false;
		}

		// -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- //
		// ウィンドウ情報設定
		// -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- //
//		private WindowInfo[] windows = new WindowInfo[3];
		List<WindowInfo> windows = new List<WindowInfo>();
		WindowInfo winTmp = null;

		private void btnFindWindow_MouseDown(object sender, MouseEventArgs e)
		{
			winTmp = null;
			Control control = (Control)sender;
			control.Capture = true;
			Cursor.Current = cursorTarget;
		}

		private void btnFindWindow_MouseMove(object sender, MouseEventArgs e)
		{
			Control control = (Control)sender;
			if (control.Capture)
			{
				// 情報取得
				Point p2 = System.Windows.Forms.Control.MousePosition;
				IntPtr hwnd = Win32dll.WindowFromPoint(p2.X, p2.Y);
				if (winTmp == null || winTmp.hwnd != hwnd)
				{
					// 旧枠削除
					if (winTmp != null)
					{
						winTmp.EraseInvertFrame();
					}
					// 差替え
					winTmp = new WindowInfo(hwnd);
					// 情報表示
					edtDetails.Text = winTmp.ToString();
					// 新枠描画
					winTmp.DrawInvertFrame();
				}
			}
		}

		private void btnFindWindow_MouseUp(object sender, MouseEventArgs e)
		{
			Control control = (Control)sender;
			// ウィンドウ確定
			if (control.Capture && winTmp != null)
			{
				// 重複チェック
				bool bOk = true;
				foreach (WindowInfo win in windows)
				{
					if (win.hwnd == winTmp.hwnd)
					{
						bOk = false;
					}
				}
				// 追加処理
				if (bOk)
				{
					windows.Add(winTmp);
					ListViewItem item = lstWindows.Items.Add("0x" + winTmp.hwnd.ToString("x8"));
					item.SubItems.Add(winTmp.className);
					item.SubItems.Add(winTmp.text);
					item.SubItems.Add(winTmp.exe);
					item.Tag = winTmp;
				}
			}
			// キャプチャ終了
			control.Capture = false;
		}

		private void btnFindWindow_MouseCaptureChanged(object sender, EventArgs e)
		{
			// 枠削除
			if (winTmp != null)
			{
				winTmp.EraseInvertFrame();
			}
			// キャンセル
			winTmp = null;
			edtDetails.Text = "";
			Cursor.Current = Cursors.Default;
		}

		// -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- //
		// ウィンドウ情報解除
		// -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- //
		private void btnRemove_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in lstWindows.SelectedItems)
			{
				windows.Remove((WindowInfo)item.Tag);
				lstWindows.Items.Remove(item);
			}
		}

		private void lstWindows_SelectedIndexChanged(object sender, EventArgs e)
		{
			string details = "";
			foreach (ListViewItem item in lstWindows.SelectedItems)
			{
				WindowInfo win = (WindowInfo)item.Tag;
				if (win != null)
				{
					details += win.ToString() + "\r\n";
				}
			}
			edtDetails.Text = details;
		}

		// -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- //
		// 定期処理
		// -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- //
		private void timer1_Tick(object sender, EventArgs e)
		{
			foreach (ListViewItem item in lstWindows.Items)
			{
				WindowInfo win  = (WindowInfo)item.Tag;
				if (!Win32dll.IsWindowEnabled(win.hwnd))
				{
					windows.Remove(win);
					lstWindows.Items.Remove(item);
				}
			}
		}

		private void btnFindWindow_Click(object sender, EventArgs e)
		{

		}

		private void btnFindWindow_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			Control control = (Control)sender;
			if (control.Capture)
			{
			}
		}

	}

	public class WindowInfo
	{
		public IntPtr hwnd;
		public string className;
		public string text;
		public string exe;
		private bool drawed = false;
		Rectangle rc = new Rectangle();

		public WindowInfo(IntPtr hwnd)
		{
			this.hwnd = hwnd;
			className = Win32dll.GetClassName(hwnd);
			text = Win32dll.GetWindowText(hwnd);
			rc = Win32dll.GetWindowRect(hwnd);

			// プロセスID取得
			uint pid = 0;
			Win32dll.GetWindowThreadProcessId(hwnd, out pid);
//			IntPtr hProcess = Win32dll.OpenProcess(Win32dll.ProcessAccessFlags.QueryInformation, true, pid);
//			IntPtr hModule = Win32dll.GetWindowLongPtr(hwnd, (int)GWL.GWL_HINSTANCE);
//			exe = Win32dll.GetModuleFileNameEx(hProcess, hModule);
//			Win32dll.CloseHandle(hProcess);

			// 実行中のすべてのプロセスを取得する
			System.Diagnostics.Process[] hProcesses = System.Diagnostics.Process.GetProcesses();

			// 取得できたプロセスからプロセス名を取得する
			foreach (System.Diagnostics.Process hProcess in hProcesses)
			{
				if (hProcess.Id == pid)
				{
					exe = hProcess.ProcessName;
					break;
				}
			}
		}

		public void DrawInvertFrame()
		{
			if (drawed) return;
			ControlPaint.DrawReversibleFrame(rc, Color.Black, FrameStyle.Thick);
			drawed = true;
		}

		public void EraseInvertFrame()
		{
			if (!drawed) return;
			ControlPaint.DrawReversibleFrame(rc, Color.Black, FrameStyle.Thick);
			drawed = false;
		}

		public string ToString()
		{
			string ret = "";
			ret += "[HWND] 0x" + hwnd.ToString("x8") + "\r\n";
//			ret += "[rc] " + rc + "\r\n";
			ret += "[className] " + className + "\r\n";
			ret += "[text] " + text + "\r\n";
			return ret;
		}
	}




}


