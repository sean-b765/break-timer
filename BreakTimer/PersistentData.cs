using System;
using System.Collections.Generic;
using System.Text;

namespace BreakTimer
{
    /*
     * Data to be serialized is stored in this class when instantiated
     */
    [Serializable]
    class PersistentData
    {
        public int _Minutes;
        public int _Style;
        public bool _Enabled;
        public string _SelectedSound;
        public string _TxtCaption;

        public PersistentData()
        {
        }
    }
}
