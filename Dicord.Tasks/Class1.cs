using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dicord.Tasks
{
    public abstract class Task
    {
        public abstract void Execute();
    }

    public class TaskService
    {
        Trigger t;

        public TaskService()
        {
            t.TriggerFired += T_TriggerFired;
        }

        private void T_TriggerFired(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public class Trigger
    {

        public delegate void TriggerFiredHandler(object sender, EventArgs e);

        public event TriggerFiredHandler TriggerFired;

    }

}
