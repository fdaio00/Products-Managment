using System;
using System.Reflection;
using System.Runtime.InteropServices;

public static class MessageBoxManager
{
    private static IntPtr _hook;
    private static IntPtr _hInstance;
    private static HookProc _hookProc;

    public static string OK = "حسنا";
    public static string Cancel = "Cancel";
    public static string Yes = "Yes";
    public static string No = "No";
    public static string Retry = "Retry";
    public static string Abort = "Abort";
    public static string Ignore = "Ignore";

    static MessageBoxManager()
    {
        _hookProc = new HookProc(MessageBoxHookProc);
        _hInstance = Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]);
    }

    public static void Register()
    {
        if (_hook != IntPtr.Zero)
            throw new NotSupportedException("One hook per thread allowed.");

        _hook = SetWindowsHookEx(WH_CBT, _hookProc, _hInstance, GetCurrentThreadId());
    }

    public static void Unregister()
    {
        if (_hook == IntPtr.Zero)
            throw new NotSupportedException("No hook to unregister.");

        UnhookWindowsHookEx(_hook);
        _hook = IntPtr.Zero;
    }

    private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

    private static IntPtr MessageBoxHookProc(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode == HCBT_ACTIVATE)
        {
            IntPtr hWnd = wParam;
            SetDlgItemText(hWnd, IDOK, OK);
            SetDlgItemText(hWnd, IDCANCEL, Cancel);
            SetDlgItemText(hWnd, IDYES, Yes);
            SetDlgItemText(hWnd, IDNO, No);
            SetDlgItemText(hWnd, IDRETRY, Retry);
            SetDlgItemText(hWnd, IDABORT, Abort);
            SetDlgItemText(hWnd, IDIGNORE, Ignore);
            Unregister();
        }
        return CallNextHookEx(_hook, nCode, wParam, lParam);
    }

    private const int WH_CBT = 5;
    private const int HCBT_ACTIVATE = 5;
    private const int IDOK = 1;
    private const int IDCANCEL = 2;
    private const int IDABORT = 3;
    private const int IDRETRY = 4;
    private const int IDIGNORE = 5;
    private const int IDYES = 6;
    private const int IDNO = 7;

    [DllImport("user32.dll")]
    private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll")]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll")]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll")]
    private static extern uint GetCurrentThreadId();

    [DllImport("user32.dll")]
    private static extern bool SetDlgItemText(IntPtr hDlg, int nIDDlgItem, string lpString);


}
