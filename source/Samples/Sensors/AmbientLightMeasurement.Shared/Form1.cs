// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Sensors;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace AmbientLightMeasurement
{
    public partial class Form1 : Form
    {
        readonly Dictionary<Guid, ProgressBar> sensorMap = new Dictionary<Guid, ProgressBar>();
        const int maxIntensity = 200;

        public Form1()
        {
            InitializeComponent();

            SensorManager.SensorsChanged += SensorManager_SensorsChanged;

            PopulatePanel();
        }

        private void PopulatePanel()
        {
            try
            {
                SensorList<AmbientLightSensor> alsList = SensorManager.GetSensorsByTypeId<AmbientLightSensor>();

                panel.Controls.Clear();

                int ambientLightSensors = 0;

                foreach (AmbientLightSensor sensor in alsList)
                {
                    // Create a new progress bar to monitor light level.
                    var pb = new ProgressBar
                    {
                        Width = 300,
                        Height = 20,
                        Top = 10 + (40 * ambientLightSensors),
                        Left = 10,
                        Maximum = maxIntensity
                    };

                    // Identify the control the bar represents.
                    var label = new Label
                    {
                        Text = "SensorId = " + sensor.SensorId.ToString(),
                        Top = pb.Top,
                        Left = pb.Right + 20,
                        Height = pb.Height,
                        Width = 300
                    };

                    // Add controls to panel.
                    panel.Controls.AddRange(new Control[] { pb, label });

                    // Map sensor id to progress bar for lookup in data report handler.
                    sensorMap[sensor.SensorId.Value] = pb;

                    // set intial progress bar value
                    _ = sensor.TryUpdateData();
                    float current = sensor.CurrentLuminousIntensity.Intensity;
                    pb.Value = Math.Min((int)current, maxIntensity);

                    // Set up automatc data report handling.
                    sensor.AutoUpdateDataReport = true;
                    sensor.DataReportChanged += DataReportChanged;

                    ambientLightSensors++;
                }

                if (ambientLightSensors == 0)
                {
                    var label = new Label
                    {
                        Text = "No Sensors Found",
                        Top = 10,
                        Left = 10,
                        Height = 20,
                        Width = 300
                    };
                    panel.Controls.Add(label);
                }
            }
            catch (SensorPlatformException)
            {
                // This exception will also be hit in the Shown message handler.
            }
        }

        void SensorManager_SensorsChanged(in SensorsChangedEventArgs change) =>
            // The sensors changed event comes in on a non-UI thread. 
            // Whip up an anonymous delegate to handle the UI update.
            _ = BeginInvoke(new MethodInvoker(delegate
            {
                PopulatePanel();
            }));

        void DataReportChanged(Sensor sender, in EventArgs e)
        {
            var als = sender as AmbientLightSensor;

            // The data report update comes in on a non-UI thread. 
            // Whip up an anonymous delegate to handle the UI update.
            _ = BeginInvoke(new MethodInvoker(delegate
            {
              // find the progress bar for this sensor
              ProgressBar pb = sensorMap[sender.SensorId.Value];

              // report data (clamp value to progress bar maximum )
              float current = als.CurrentLuminousIntensity.Intensity;
                pb.Value = Math.Min((int)current, maxIntensity);
            }));
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            try
            {
                // ask for sensor permission if needed
                SensorList<Sensor> sl = SensorManager.GetAllSensors();
                SensorManager.RequestPermission(Handle, true, sl);
            }
            catch (SensorPlatformException spe)
            {
                var dialog = new TaskDialog
                {
                    InstructionText = spe.Message,
                    Text = "This application will now exit.",
                    StandardButtons = TaskDialogStandardButtons.Close
                };
                _ = dialog.Show();
                Application.Exit();
            }
        }



    }
}
