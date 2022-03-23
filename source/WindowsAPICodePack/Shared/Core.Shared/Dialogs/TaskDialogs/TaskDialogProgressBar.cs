//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Resources;
using Microsoft.WindowsAPICodePack.Win32Native.Dialogs;
using System;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Provides a visual representation of the progress of a long running operation.
    /// </summary>
    public class TaskDialogProgressBar : TaskDialogBar
    {
        private int _minimum;
        private int _value;
        private int _maximum = TaskDialogDefaults.ProgressBarMaximumValue;

        /// <summary>
        /// Gets or sets the minimum value for the control.
        /// </summary>                
        public int Minimum
        {
            get => _minimum;

            set
            {
#if CS8
                static
#endif
                    ArgumentException getException(in string msg) => new
#if !CS9
                    ArgumentException
#endif                    
                    (msg, nameof(value));

                UpdateProperty(nameof(Minimum), () => _minimum =
                     // Check for positive numbers
                     value < 0
                     ? throw getException(LocalizedMessages.TaskDialogProgressBarMinValueGreaterThanZero)
                     // Check if min / max differ
                     : value >= Maximum
                     ? throw getException(LocalizedMessages.TaskDialogProgressBarMinValueLessThanMax)
                     : value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum value for the control.
        /// </summary>
        public int Maximum
        {
            get => _maximum; set => UpdateProperty(nameof(Maximum), () => _maximum =
                // Check if min / max differ
                value < Minimum
                ? throw new ArgumentException(LocalizedMessages.TaskDialogProgressBarMaxValueGreaterThanMin, nameof(value))
                : value);
        }

        /// <summary>
        /// Gets or sets the current value for the control.
        /// </summary>
        public int Value
        {
            get => _value; set => UpdateProperty(nameof(Value), () => _value =
                // Check for positive numbers
                value < Minimum || value > Maximum
                ? throw new ArgumentException(LocalizedMessages.TaskDialogProgressBarValueInRange, nameof(value))
                : value);
        }

        /// <summary>
        /// Verifies that the progress bar's value is between its minimum and maximum.
        /// </summary>
        internal bool HasValidValues => _minimum <= _value && _value <= _maximum;

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public TaskDialogProgressBar() { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of this class with the specified name.
        /// And using the default values: Min = 0, Max = 100, Current = 0
        /// </summary>
        /// <param name="name">The name of the control.</param>        
        public TaskDialogProgressBar(in string name) : base(name) { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of this class with the specified 
        /// minimum, maximum and current values.
        /// </summary>
        /// <param name="minimum">The minimum value for this control.</param>
        /// <param name="maximum">The maximum value for this control.</param>
        /// <param name="value">The current value for this control.</param>        
        public TaskDialogProgressBar(in int minimum, in int maximum, in int value)
        {
            Minimum = minimum;
            Maximum = maximum;
            Value = value;
        }

        protected void UpdateProperty(in string propertyName, in Action action)
        {
            CheckPropertyChangeAllowed(propertyName);

            action();

            ApplyPropertyChange(propertyName);
        }

        /// <summary>
        /// Resets the control to its minimum value.
        /// </summary>
        protected internal override void Reset()
        {
            base.Reset();
            _value = _minimum;
        }
    }
}
