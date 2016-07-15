using System;

namespace SourceCodeCounter.Process
{
    public delegate void TaskStartNotifyHandler(object sender, EventArgs args);
    public delegate void TaskNotifyHandler(object sender, TaskEventArgs args);
    public delegate void TaskInfoNotifyHandler(object sender, TaskInfoEventArgs args);
    public delegate void TaskCompleteNotifyHandler(object sender, TaskCompleteEventArgs args);
    public delegate void TaskExceptionNotifyHandler(object sender, TaskExceptionEventArgs args);
    public delegate void TaskProgressChangedEventHandler(object sender, TaskProgressChangedEventArgs e);
    
}