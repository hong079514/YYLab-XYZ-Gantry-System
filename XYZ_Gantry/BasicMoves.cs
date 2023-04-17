
// Example 3 Basic Moves Rev 4
//
// This program demonstrates how to perform basic trap profile move.
//
// This program demonstrates the following types of motion:
// 1. Trapezoidal move 
// 2. Halt move
//
// This program assumes the following axis configuration:
// 1. Upon startup it will enable axis at Can Node ID 1.
// 2. The motor has an encoder with an index
//
// This code also includes the following prerequisites:
// 1. The amplifier and motor must be preconfigured and set up properly to run.
// 2. The hardware enable switch must be installed and easily accessible
//
// As with any motion product extreme caution must used! Read and understand
// all parameter settings before attemping to send to amplifier.
//
//
// Copley Motion Objects are Copyright, 2002-2018, Copley Controls.
//
// For more information on Copley Motion products see:
// http://www.copleycontrols.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMLCOMLib;
using System.Threading;
using System.IO;
using LabJack.LabJackUD;






//----------------------end new program------------------------

namespace EX3_BasicMoves
{

    
  

    public partial class BasicMoves : Form
    {
        //***************************************************
        //
        //  CANOpen Network
        //
        //***************************************************
        const int X_AXIS_CAN_ADDRESS = 1;
        const int X2_AXIS_CAN_ADDRESS = 2;
        const int Y_AXIS_CAN_ADDRESS = 3;
        const int Z_AXIS_CAN_ADDRESS = 4;

        // comment by YZY:  before is the address for each 4 axis


        canOpenObj canOpen;

        const int LOG_ALL = 99;
        CopleyMotionLibraryObj cmlObj;

        AmpObj xAxisAmp;
        AmpObj x2AxisAmp;
        AmpObj yAxisAmp;
        AmpObj zAxisAmp;
        ProfileSettingsObj ProfileSettings_x;
        ProfileSettingsObj ProfileSettings_x2;
        ProfileSettingsObj ProfileSettings_y;
        ProfileSettingsObj ProfileSettings_z;
        HomeSettingsObj Home;
		public static bool sequence_done = false;
		public static bool halt_button_clicked = false;

		public static bool x_inMotion, y_inMotion, z_inMotion = false;
		public static bool green_light_status = false;
		public static bool is_capturing = false;
		public static bool red_light_status = false;


        int off_set = -10000;
        // before is the initiliztion of varibales, need to mention that off_set means after each "home", axis will move on the relative way for paticular meters



        // Create a delegate to close down the application in a thread safe way
        delegate void CloseApp();

        public BasicMoves()
        {
            InitializeComponent();
        }


        // ---------------------------------------labjack-----------------
        class U3_EFunctions
        {
            // our U3 variable
            private U3 u3;
			double dblValue = 0;
			int intValue = 0;

			int binary;
			int[] aEnableTimers = new int[2];
			int[] aEnableCounters = new int[2];
			int tcpInOffset;
			int timerClockDivisor;
			LJUD.TIMERCLOCKS timerClockBaseIndex;
			int[] aTimerModes = new int[2];
			double[] adblTimerValues = new double[2];
			int[] aReadTimers = new int[2];
			int[] aUpdateResetTimers = new int[2];
			int[] aReadCounters = new int[2];
			int[] aResetCounters = new int[2];
			double[] adblCounterValues = { 0, 0 };
			double highTime, lowTime, dutyCycle;


			// If error occured print a message indicating which one occurred. If the error is a group error (communication/fatal), quit
			public void showErrorMessage(LabJackUDException e) // related to labjack( led to show command)
            {
                Console.Out.WriteLine("Error: " + e.ToString());
                if (e.LJUDError > U3.LJUDERROR.MIN_GROUP_ERROR)
                {
                    Console.ReadLine(); // Pause for the user
                    Environment.Exit(-1);
                }
            }


            public void performActions() // fuction for labjack to fullfil
            {
                double dblValue = 0;
                int intValue = 0;

                int binary;
                int[] aEnableTimers = new int[2];
                int[] aEnableCounters = new int[2];
                int tcpInOffset;
                int timerClockDivisor;
                LJUD.TIMERCLOCKS timerClockBaseIndex;
                int[] aTimerModes = new int[2];
                double[] adblTimerValues = new double[2];
                int[] aReadTimers = new int[2];
                int[] aUpdateResetTimers = new int[2];
                int[] aReadCounters = new int[2];
                int[] aResetCounters = new int[2];
                double[] adblCounterValues = { 0, 0 };
                double highTime, lowTime, dutyCycle;

                try
				{

					//Open the first found LabJack U3.
					u3 = new U3(LJUD.CONNECTION.USB, "0", true); // Connection through USB

                    //Start by using the pin_configuration_reset IOType so that all
                    //pin assignments are in the factory default condition.
                    LJUD.ePut(u3.ljhandle, LJUD.IO.PIN_CONFIGURATION_RESET, 0, 0, 0);

					// LabJack U3 utput channel
					// DAC0 = 0, DAC1 = 1, AIN2 = 2, AIN3 = 3 
					// FIO4 = 4, FIO5 = 5, FIO6 = 6, FIO7 = 7
					int channel = 0;

                    //Set DAC0 to 3.0 volts.
                    dblValue = 3.0;

                    binary = 0;
                    //LJUD.eDAC(u3.ljhandle, 0, dblValue, binary, 0, 0);
                    Console.Out.WriteLine("DAC1 set to {0:0.###} volts\n", dblValue);


                    //wait 1 second
                    Thread.Sleep(1000); //Wait 1 second.
                    //off
                    LJUD.eDAC(u3.ljhandle, channel, 0, binary, 0, 0);

                    //wait 1 second
                    Thread.Sleep(1000); //Wait 1 second.
                    //on
                    LJUD.eDAC(u3.ljhandle, channel, dblValue, binary, 0, 0);


					//wait 1 second
					Thread.Sleep(1000); //Wait 1 second.
                    //off
                    LJUD.eDAC(u3.ljhandle, channel, 0, binary, 0, 0);

                    Console.Out.WriteLine("DAC1 set111111 to 0 volts\n");
                }
                catch (LabJackUDException e)
                {
                    showErrorMessage(e);
                }
            }

			private void call()
			{
				throw new NotImplementedException();
			}

			public bool set_light()// sets the status of the light
			{
				// true = light should turn on
				// false = light should turn off

				if (green_light_status == false)
				{
					green_light_status = true;
					return green_light_status;
				}

				else
				{
					green_light_status = false;
					return green_light_status;
				}
			}

			// Status light indicator for when motors in motion
			// LabJack U3 output channel
			// DAC0 = 0, DAC1 = 1, AIN2 = 2, AIN3 = 3 
			// FIO4 = 4, FIO5 = 5, FIO6 = 6, FIO7 = 7 
			public void statusLightOn(int channel)
			{
				

				try
				{
					//Open the first found LabJack U3.
					u3 = new U3(LJUD.CONNECTION.USB, "0", true); // Connection through USB

					//Start by using the pin_configuration_reset IOType so that all
					//pin assignments are in the factory default condition.
					LJUD.ePut(u3.ljhandle, LJUD.IO.PIN_CONFIGURATION_RESET, 0, 0, 0);

					// LabJack U3 output channel
					// DAC0 = 0, DAC1 = 1, AIN2 = 2, AIN3 = 3 
					// FIO4 = 4, FIO5 = 5, FIO6 = 6, FIO7 = 7 

					//Set DAC0 to 3.0 volts.
					dblValue = 3.0;

					binary = 0;
					//LJUD.eDAC(u3.ljhandle, 0, dblValue, binary, 0, 0);
					Console.Out.WriteLine("DAC1 set to {0:0.###} volts\n", dblValue);

					// Set the light indicator on
					LJUD.eDAC(u3.ljhandle, channel, dblValue, binary, 0, 0);
					set_light();

					Console.Out.WriteLine("DAC1 set111111 to 0 volts\n");
				}
				catch (LabJackUDException e)
				{
					showErrorMessage(e);
				}
			}

			public void statusLightOff(int channel)
			{

				try
				{
					//Open the first found LabJack U3.
					u3 = new U3(LJUD.CONNECTION.USB, "0", true); // Connection through USB

					//Start by using the pin_configuration_reset IOType so that all
					//pin assignments are in the factory default condition.
					LJUD.ePut(u3.ljhandle, LJUD.IO.PIN_CONFIGURATION_RESET, 0, 0, 0);

					// LabJack U3 utput channel
					// DAC0 = 0, DAC1 = 1, AIN2 = 2, AIN3 = 3 
					// FIO4 = 4, FIO5 = 5, FIO6 = 6, FIO7 = 7 

					//Set DAC0 to 3.0 volts.
					// dblValue = 3.0;

					binary = 0;
					//LJUD.eDAC(u3.ljhandle, 0, dblValue, binary, 0, 0);
					Console.Out.WriteLine("DAC1 set to {0:0.###} volts\n", dblValue);

					// Set the light indicator off
					LJUD.eDAC(u3.ljhandle, channel, 0, binary, 0, 0);
					set_light();

					Console.Out.WriteLine("DAC1 set111111 to 0 volts\n");
				}
				catch (LabJackUDException e)
				{
					showErrorMessage(e);
				}
			}
		}
        // ---------------------------------------labjack-----------------


        private void BasicMoves_Load(object sender, EventArgs e) // initializtion of basicmove variables
        {
            try
            {
                //**************************************************************************
                //* Turn on logging by setting a CML object
                //**************************************************************************
                cmlObj = new CopleyMotionLibraryObj();
                cmlObj.DebugLevel = LOG_ALL;

                //Initialize code here
                // create an AmpObj type varible will have several steps, step 1 is below
                xAxisAmp = new AmpObj();
                x2AxisAmp = new AmpObj();
                yAxisAmp = new AmpObj();
                zAxisAmp = new AmpObj();


                //***************************************************
                //
                //  CANOpen Network
                //
                //***************************************************
                canOpen = new canOpenObj();
                //
                //**************************************************************************
               
                //* then the default bit rate (1 Mbit per second) is used.  If no port name
                //* is specified, then CMO will use the first supported CAN card found and
                //* use channel 0 of that card.
                //**************************************************************************
                // Set the bit rate to 1 Mbit per second
                canOpen.BitRate = CML_BIT_RATES.BITRATE_1_Mbit_per_sec;
                // Indicate that channel 0 of a Copley CAN card should be used
                canOpen.PortName = "copley0";
                //***************************************************
                //* Initialize the CAN card and network
                //***************************************************
                canOpen.Initialize();
                //***************************************************
                //* Initialize the amplifier
                //***************************************************

                //step2: initialize amplifer
                xAxisAmp.Initialize(canOpen, X_AXIS_CAN_ADDRESS);
                x2AxisAmp.Initialize(canOpen, X2_AXIS_CAN_ADDRESS);
                yAxisAmp.Initialize(canOpen, Y_AXIS_CAN_ADDRESS);
				zAxisAmp.Initialize(canOpen, Z_AXIS_CAN_ADDRESS);

                // Read velocity loop settings from the amp, use these as reasonble starting
                // points for the trajectory limits.
                VelocityTextBox.Text = Convert.ToString((xAxisAmp.VelocityLoopSettings.VelLoopMaxVel) / 10);
                AccelTextBox.Text = Convert.ToString((xAxisAmp.VelocityLoopSettings.VelLoopMaxAcc) / 10);
                DecelTextBox.Text = Convert.ToString((xAxisAmp.VelocityLoopSettings.VelLoopMaxDec) / 10);

                // Initialize home object with amplifier home settings 
                Home = xAxisAmp.HomeSettings;
				Home = yAxisAmp.HomeSettings;

				// Runs a thread parallelly for motor motion status
				// Light indicator of motor in motion
				Thread light_indicator = new Thread(lightIndicator);
				light_indicator.Start();


				Timer1.Start();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

		private void CaptureIndicator()
		{
			U3_EFunctions capture_status_light = new U3_EFunctions();

			bool flag = true;

			while (flag)
			{
				if (is_capturing == true)
				{
					capture_status_light.statusLightOn(0);
					// captureRed();
				}
				else
				{
					capture_status_light.statusLightOff(0);
					// captureWhite();
				}
			}
		}

		private bool set_capture_status()
		{
			if (is_capturing == false)
			{
				return is_capturing = true;
			}
			else
			{
				return is_capturing = false;
			}
		}

		private void Y_Go_Home() // Function that moves y-axis to default home position
		{


			int Distance_y = Convert.ToInt32(Modified_Y_Textbox.Text);

			ProfileSettings_y = yAxisAmp.ProfileSettings;
			ProfileSettings_y.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;

			ProfileSettings_y.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
			ProfileSettings_y.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
			ProfileSettings_y.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

			yAxisAmp.ProfileSettings = ProfileSettings_y;

			CML_EVENT_STATUS current_xHome_status = 0; // the sensor will send signal back if axis reach the limit

			// Disables Home button if it is already at default home position
			if ((CML_EVENT_STATUS)(current_xHome_status & CML_EVENT_STATUS.EVENT_STATUS_POSITIVE_LIMIT) == CML_EVENT_STATUS.EVENT_STATUS_POSITIVE_LIMIT)
			{
				HomeAxisButton.Enabled = false;
			}

			// Otherwise starts Home sequence
			else
			{

				// End of test watit

				//HomeAxisButton.Enabled = false;
				// below is the speed parament related to home
				Home.HomeVelFast = 4000;
				Home.HomeVelSlow = 4000;
				Home.HomeAccel = 1000;
				Home.HomeMethod = CML_HOME_METHOD.CHOME_POSITIVE_LIMIT; // Set the home location to the positive limit sensor
				Home.HomeOffset = 0;


				// read profile settings from amp
				ProfileSettings_y = yAxisAmp.ProfileSettings;

				//Set the profile type for move
				ProfileSettings_y.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;

				//Set the profile trajectory values 
				ProfileSettings_y.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
				ProfileSettings_y.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
				ProfileSettings_y.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

				ProfileSettings_x = yAxisAmp.ProfileSettings; // read profile settings from amp
				yAxisAmp.MoveRel(2000000);

				CML_EVENT_STATUS yAxis_stop_status = 0; // the sensor will send signal back if axis reach the limit
				bool flag = true;

				//x2AxisAmp.ReadEventStatus(ref xAxis_stop_status);

				Boolean stopClick = true;
				set_y_motion_status();

				// constantly checking if x reaching the limit
				while (flag && stopClick)
				{
					yAxisAmp.ReadEventStatus(ref yAxis_stop_status);

					Console.WriteLine(y_inMotion);
					// Checking if the y sensor is active
					if ((CML_EVENT_STATUS)(yAxis_stop_status & CML_EVENT_STATUS.EVENT_STATUS_POSITIVE_LIMIT) == CML_EVENT_STATUS.EVENT_STATUS_POSITIVE_LIMIT)
					{
						flag = false; // if the limit is reached, breaks from loop
									  //Testing

						// Console.WriteLine(" Test at line 332 Home if statement  ");// test message
					}

				}
				// halt the move of y axis
				yAxisAmp.HaltMove();
				set_y_motion_status();
				


				//doMoveButton.Enabled = true;

			}

		}

		private void X_Go_Home() // Function that moves x-axis to default home position
		{
			//Test profile setting
			int Modified_Distance_x = Convert.ToInt32(Modified_X_Textbox.Text);
			//int Modified_Distance_y = Convert.ToInt32(Modified_Y_Textbox.Text);

			ProfileSettings_x = xAxisAmp.ProfileSettings; // read profile settings from amp,step1
			ProfileSettings_x2 = x2AxisAmp.ProfileSettings;

			//ProfileSettings_y = yAxisAmp.ProfileSettings;

			//Set the profile type for move, step2
			ProfileSettings_x.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;
			ProfileSettings_x2.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;
			//ProfileSettings_y.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;

			//Set the profile trajectory values , step3
			ProfileSettings_x.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
			ProfileSettings_x.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
			ProfileSettings_x.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

			ProfileSettings_x2.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
			ProfileSettings_x2.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
			ProfileSettings_x2.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

			//ProfileSettings_y.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
			//ProfileSettings_y.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
			//ProfileSettings_y.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

			// Update the amplier's profile settigns, step4
			xAxisAmp.ProfileSettings = ProfileSettings_x;
			x2AxisAmp.ProfileSettings = ProfileSettings_x2;
			//yAxisAmp.ProfileSettings = ProfileSettings_y;
			//end of profile setting test test

			CML_EVENT_STATUS current_xHome_status = 0; // the sensor will send signal back if axis reach the limit

			// Disables Home button if it is already at default home position
			if ((CML_EVENT_STATUS)(current_xHome_status & CML_EVENT_STATUS.EVENT_STATUS_POSITIVE_LIMIT) == CML_EVENT_STATUS.EVENT_STATUS_POSITIVE_LIMIT)
			{
				HomeAxisButton.Enabled = false;
			}

			// Otherwise starts Home sequence
			else
			{

				// End of test watit

				HomeAxisButton.Enabled = false;
				// below is the speed parament related to home
				Home.HomeVelFast = 4000;
				Home.HomeVelSlow = 4000;
				Home.HomeAccel = 1000;
				Home.HomeMethod = CML_HOME_METHOD.CHOME_POSITIVE_LIMIT; // Set the home location to the positive limit sensor
				Home.HomeOffset = 0;


				// read profile settings from amp
				ProfileSettings_x = xAxisAmp.ProfileSettings;
				ProfileSettings_x2 = x2AxisAmp.ProfileSettings;

				//Set the profile type for move
				ProfileSettings_x.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;
				ProfileSettings_x2.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;

				//Set the profile trajectory values 
				ProfileSettings_x.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
				ProfileSettings_x.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
				ProfileSettings_x.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

				ProfileSettings_x2.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
				ProfileSettings_x2.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
				ProfileSettings_x2.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

				ProfileSettings_x = xAxisAmp.ProfileSettings; // read profile settings from amp
				xAxisAmp.MoveRel(2000000);

				ProfileSettings_x2 = x2AxisAmp.ProfileSettings;
				x2AxisAmp.MoveRel(2000000);




				//y go home
				//Testing
				Console.WriteLine(" Test at line 314 Y go home statement  ");// test message
																				 //Testing
				Home = yAxisAmp.HomeSettings;


				Console.WriteLine(" Test at line 278 Home else statement ");// test message
																				// Initialize home object with amplifier home settings 
				//Home.HomeVelFast = (yAxisAmp.VelocityLoopSettings.VelLoopMaxVel) / 10;
				//Home.HomeVelSlow = (yAxisAmp.VelocityLoopSettings.VelLoopMaxVel) / 10;
				//Home.HomeAccel = yAxisAmp.VelocityLoopSettings.VelLoopMaxAcc / 10;
				//Home.HomeMethod = CML_HOME_METHOD.CHOME_INDEX_POSITIVE;
				//Home.HomeOffset = 0;
				//yAxisAmp.HomeSettings = Home;
				//yAxisAmp.GoHome();
				//Test wait

				// set x motion status as active(true)
				set_x_motion_status();
				
				Console.WriteLine(" Test at line 343 Y moved ");// test message
																	//end of test
				CML_EVENT_STATUS xAxis_stop_status = 0; // the sensor will send signal back if axis reach the limit
				bool flag = true;

				//x2AxisAmp.ReadEventStatus(ref xAxis_stop_status);

				Boolean stopClick = true;

				// constantly checking if x reaching the limit
				while (flag && stopClick)
				{
					xAxisAmp.ReadEventStatus(ref xAxis_stop_status);


					// Checking if the x1 sensor is active
					if ((CML_EVENT_STATUS)(xAxis_stop_status & CML_EVENT_STATUS.EVENT_STATUS_POSITIVE_LIMIT) == CML_EVENT_STATUS.EVENT_STATUS_POSITIVE_LIMIT)
					{
						flag = false; // if the limit is reached, breaks from loop
										  //Testing

						Console.WriteLine(" Test at line 332 Home if statement  ");// test message
					}

				}

				// halt the move of both x axles 
				x2AxisAmp.HaltMove();
				xAxisAmp.HaltMove();
				// set x motion status as inactive(false)
				set_x_motion_status();


				doMoveButton.Enabled = true;

				// HomeAxisButton.Enabled = true;
			}
	
		}

		private void lightIndicator() // Green light indicator for when motor is in motion
		{
			// test status light on 
			U3_EFunctions status_light = new U3_EFunctions();

			// test status light off
			bool flag = true;
			while (flag)
			{
				if (x_inMotion == true || y_inMotion == true || z_inMotion == true)
				{
					if(green_light_status == false)
					{
						status_light.statusLightOn(1); // parameter '1' is the channel number for DAC1 on LabJack U3
					}
					
				}
				else
				{
					if (green_light_status == true)
					{
						status_light.statusLightOff(1);  // parameter '1' is the channel number for DAC1 on LabJack U3
					}
				}
				Thread.Sleep(100);
			}
			

		}

		private bool set_x_motion_status() // set x motion status as the opposite of current status
		{
			if (x_inMotion == true)
			{
				x_inMotion = false;
				return x_inMotion;
			}
			else
			{
				x_inMotion = true;
				return x_inMotion;
			}
		}
		private bool set_y_motion_status() // set y motion status as the opposite of current status
		{
			if (y_inMotion == true)
			{
				y_inMotion = false;
				return y_inMotion;
			}
			else
			{
				y_inMotion = true;
				return y_inMotion;
			}
		}
		private bool set_z_motion_status() // set z motion status as the opposite of current status
		{
			if (z_inMotion == true)
			{
				z_inMotion = false;
				return z_inMotion;
			}
			else
			{
				z_inMotion = true;
				return z_inMotion;
			}
		}
		private void HomeAxisButton_Click(object sender, EventArgs e)// function realted to home
        {

			//wait 0.1 second
			Thread.Sleep(100); //Wait 0.1 second.
								//off
			Console.WriteLine(" Test at line 259 wait statement ");// test message
																   
			try
			{

				//Testing halt before going home to break scan sequence
				HaltMoveUtil();
				//end test

				HomeAxisButton.Enabled = false;

				Thread x_go_home = new Thread(X_Go_Home);
				Thread y_go_home = new Thread(Y_Go_Home);

				y_go_home.Start();
				x_go_home.Start();
		
			}
			catch (Exception ex)
			{
				HomeAxisButton.Enabled = true;
				DisplayError(ex);
			}

		}


        private void enableButton_Click(object sender, EventArgs e)//enable or disable the amplifier
        {
            try
            {
                if (enableButton.Text == "Amp Disable")
                {
                    xAxisAmp.Disable();
                    enableButton.Text = "Amp Enable";
                }
                else
                {
                    xAxisAmp.Enable();
                    enableButton.Text = "Amp Disable";
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
			Position_Status();
        }

		// Function to display positions in counts
		private void Position_Status()
		{
			try
			{
				//Read and display actual position 
				posTextBox.Text = Convert.ToString(xAxisAmp.PositionActual);
				x2Pos.Text = Convert.ToString(x2AxisAmp.PositionActual);
				y_postextbox.Text = Convert.ToString(yAxisAmp.PositionActual);
			}
			catch (Exception ex)
			{
				Timer1.Stop();
				DisplayError(ex);
			}
		}

		// Function of scanning sequence
		private void scan_sequence()
		{

			try
			{

				//Haltove to enable amplifiers
				//Scan without Haltmove step might crash the program duing scanning
				// now halt the move
				xAxisAmp.HaltMove();
				x2AxisAmp.HaltMove();
				yAxisAmp.HaltMove();
				//---end of test-haltove

				



				//HomeAxisButton.Enabled = false;
				//doMoveButton.Enabled = false;

				int Distance_x;
				int Distance_y;
				int flag = 1;
				int step_x;
				int step_y;

				int delay_Time = 5000;


				// a temp varible to document the input value for x axis to move
				Distance_x = Convert.ToInt32(X_DistanceTextBox.Text);
				Distance_y = Convert.ToInt32(Y_DistanceTextBox.Text);

				int tmp = Distance_y;

				// a temp varible to document the input value for x axis to move each time
				step_x = Convert.ToInt32(X_StepTextBox.Text);
				step_y = Convert.ToInt32(Y_StepTextBox.Text);


				//step 1
				ProfileSettings_x = xAxisAmp.ProfileSettings; // read profile settings from amp
				ProfileSettings_x2 = x2AxisAmp.ProfileSettings;
				ProfileSettings_y = yAxisAmp.ProfileSettings;

				//Set the profile type for move, step2
				ProfileSettings_x.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;
				ProfileSettings_x2.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;
				ProfileSettings_y.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;
				//Set the profile trajectory values , step3
				ProfileSettings_x.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
				ProfileSettings_x.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
				ProfileSettings_x.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

				ProfileSettings_x2.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
				ProfileSettings_x2.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
				ProfileSettings_x2.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

				ProfileSettings_y.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
				ProfileSettings_y.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
				ProfileSettings_y.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

				// Update the amplier's profile settigns, step4
				xAxisAmp.ProfileSettings = ProfileSettings_x;
				x2AxisAmp.ProfileSettings = ProfileSettings_x2;
				yAxisAmp.ProfileSettings = ProfileSettings_y;


				


				// Execute the move need to change
				int i = 1;
				int i_2 = 1;

				// write the running output to excel
				string filePath = @"C:\Users\ljw5330\Desktop\Position.csv";
				string stringLine;
				string stringHeader = "x,y,z" + "\r\n";

				File.WriteAllText(filePath, stringHeader);

				U3_EFunctions a = new U3_EFunctions();// related to led

				while (Distance_x > 0 && halt_button_clicked == false)// below is the loop for xy to move in a certain pattern
				{


					Console.WriteLine("current while loop is " + i);// log message
					i += 1;
					if (flag == 1)
					{
						if (Distance_y > 0)
						{


							// Flash LED
							a.performActions();
							Console.WriteLine("y pos.");
							set_y_motion_status();
							yAxisAmp.MoveRel(-step_y);

							//wait
							Thread.Sleep(delay_Time);
							set_y_motion_status();

							Distance_y -= step_y;
							Console.WriteLine("current distance_y == " + Distance_y);

							Console.WriteLine(" current distance_x == " + Distance_x);

							i_2 += 1;

						}
						// Move x
						if (Distance_y <= 0)// when Y finsish its move, X should move 1 step
						{
							flag = -1;
							Distance_y = tmp;

							// Flash LED
							a.performActions();
							Console.WriteLine("x move y pos.");

							set_x_motion_status();
							xAxisAmp.MoveRel(-step_x);
							x2AxisAmp.MoveRel(-step_x);

							//Console.ReadKey();
							Thread.Sleep(delay_Time);
							set_x_motion_status();

							Distance_x -= step_x;
							Console.WriteLine(" current distance_y == " + Distance_y);
							Console.WriteLine(" X moved,y going negative  ");

							Console.WriteLine(" ycurrent distance_x == " + Distance_x);


						}
					}
					else// when flag not equall to 1, means a positive way
					{
						// Flash LED
						a.performActions();
						Console.WriteLine("y neg.");

						yAxisAmp.MoveRel(step_y);
						//wait
						set_y_motion_status();
						Thread.Sleep(delay_Time);
						set_y_motion_status();

						Distance_y -= step_y;
						Console.WriteLine(" 2ndcurrent distance_y == " + Distance_y);

						Console.WriteLine(" 2ndcurrent distance_x == " + Distance_x);

						// Move x
						if (Distance_y <= 0)
						{
							flag = 1;
							Distance_y = tmp;
							// Flash LED
							a.performActions();
							Console.WriteLine("x move y neg.");

							set_x_motion_status();
							xAxisAmp.MoveRel(-step_x);
							x2AxisAmp.MoveRel(-step_x);

							// Console.ReadKey();
							Thread.Sleep(delay_Time);
							set_x_motion_status();

							Distance_x -= step_x;
							Console.WriteLine(" current distance_y == " + Distance_y);
							Console.WriteLine(" X moved,y going postive  ");
							Console.WriteLine(" current distance_x == " + Distance_x);

						}
					}

					// write position data to cvs file
					string x_position = Convert.ToString(xAxisAmp.PositionActual);
					string y_position = Convert.ToString(yAxisAmp.PositionActual);
					string z_position = Convert.ToString(zAxisAmp.PositionActual);

					stringLine = x_position + "," + y_position + "," + z_position + "\r\n";
					//write xyz positon to file
					File.AppendAllText(filePath, stringLine);

				}
				if (Distance_x <= 0)
				{
					// Flash LED
					a.performActions();

					Console.WriteLine(" xxxx reach the finish line ");
				}
				//HomeAxisButton.Enabled = true;
				//doMoveButton.Enabled = true;
				halt_button_clicked = false;
			}

			catch (Exception ex)
			{
				doMoveButton.Enabled = true;
				HomeAxisButton.Enabled = true;
				DisplayError(ex);
			}
			
		}


        // Scan sequence GUI button click
        private void doMoveButton_Click(object sender, EventArgs e) 
        {

			//HomeAxisButton.Enabled = false;
			//doMoveButton.Enabled = false;
			Thread thrd1 = new Thread(Position_Status);		// create a new thread to update position status while scan_sequence rinning
			Thread thrd2 = new Thread(scan_sequence);		// a thread for scanning sequence
			thrd1.Start();
			thrd2.Start();
			// thrd2.Join();

			//HomeAxisButton.Enabled = true;
			//doMoveButton.Enabled = true;
        }


        private void Modified_Button_Click(object sender, EventArgs e)// function realted to modified move, means move to a paticular position
        {


            int Modified_Distance_x = Convert.ToInt32(Modified_X_Textbox.Text);
            int Modified_Distance_y = Convert.ToInt32(Modified_Y_Textbox.Text);
			int vel = Convert.ToInt32(VelocityTextBox.Text);

            ProfileSettings_x = xAxisAmp.ProfileSettings; // read profile settings from amp,step1
            ProfileSettings_x2 = x2AxisAmp.ProfileSettings;

            ProfileSettings_y = yAxisAmp.ProfileSettings;

            //Set the profile type for move, step2
            ProfileSettings_x.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;
            ProfileSettings_x2.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;
            ProfileSettings_y.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;

            //Set the profile trajectory values , step3
            ProfileSettings_x.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
            ProfileSettings_x.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
            ProfileSettings_x.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

            ProfileSettings_x2.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
            ProfileSettings_x2.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
            ProfileSettings_x2.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

            ProfileSettings_y.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
            ProfileSettings_y.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
            ProfileSettings_y.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

            // Update the amplier's profile settigns, step4
            xAxisAmp.ProfileSettings = ProfileSettings_x;
            x2AxisAmp.ProfileSettings = ProfileSettings_x2;
            yAxisAmp.ProfileSettings = ProfileSettings_y;

			// choose the larger distance
			int max_dist = Math.Abs(Modified_Distance_x);
			if (Math.Abs(Modified_Distance_y) > Math.Abs(Modified_Distance_x))
			{
				max_dist = Modified_Distance_y;
			}

			// set x and y axis status to moving
			set_x_motion_status();
			set_y_motion_status();
			// move
			xAxisAmp.MoveRel(Modified_Distance_x);
            x2AxisAmp.MoveRel(Modified_Distance_x);
            yAxisAmp.MoveRel(Modified_Distance_y);


			// wait for this amount of time: (|distance| / velocity) * 1000 milliseconds
			Thread.Sleep((Math.Abs(max_dist) / vel) * 1000);

			// set x and y axis status to stopped
			set_x_motion_status();
			set_y_motion_status();

			HomeAxisButton.Enabled = true;

        }

		// move z axis upward
        private void Move_Z_Up_Button_Click(object sender, EventArgs e)
        {
            ProfileSettings_z = zAxisAmp.ProfileSettings; // read profile settings from amp

            //Set the profile type for move
            ProfileSettings_z.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;

            //Set the profile trajectory values 
            ProfileSettings_z.ProfileAccel = 10000;
            ProfileSettings_z.ProfileDecel = 10000;
            ProfileSettings_z.ProfileVel = 4000;

            

            // Update the amplier's profile settigns
            zAxisAmp.ProfileSettings = ProfileSettings_z;

			set_z_motion_status(); // set z axis status to moving
            zAxisAmp.MoveRel(-500);
			Thread.Sleep(500);
			set_z_motion_status();// set z axis status to stopped

        }

		// Move Z axis downward
        private void Move_Z_down_Button_Click(object sender, EventArgs e) 
        {

            ProfileSettings_z = zAxisAmp.ProfileSettings; // read profile settings from amp

            //Set the profile type for move
            ProfileSettings_z.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;

            //Set the profile trajectory values 
            ProfileSettings_z.ProfileAccel = 10000;
            ProfileSettings_z.ProfileDecel = 10000;
            ProfileSettings_z.ProfileVel = 4000;



            // Update the amplier's profile settigns
            zAxisAmp.ProfileSettings = ProfileSettings_z;

			set_z_motion_status(); // set z asix status to moving
            zAxisAmp.MoveRel(500);
			Thread.Sleep(500);
			set_z_motion_status(); // set z axis status to stopped
        }

		private void HaltMoveUtil() // utility function for halting moves 
		{
			doMoveButton.Enabled = false;
			HomeAxisButton.Enabled = false;

			halt_button_clicked = true;

			//set halt mode desired before halting the move
			xAxisAmp.HaltMode = CML_HALT_MODE.HALT_DECEL;
			x2AxisAmp.HaltMode = CML_HALT_MODE.HALT_DECEL;
			yAxisAmp.HaltMode = CML_HALT_MODE.HALT_DECEL;

			// now halt the move
			xAxisAmp.HaltMove();
			x2AxisAmp.HaltMove();
			yAxisAmp.HaltMove();

			if (x_inMotion == true)
			{
				set_x_motion_status();
			}
			if (y_inMotion == true)
			{
				set_y_motion_status();
			}
			if (z_inMotion == true)
			{
				set_z_motion_status();
			}


			doMoveButton.Enabled = true;

			HomeAxisButton.Enabled = true;

		}

		private void haltMoveButton_Click(object sender, EventArgs e)// stop moving during any movement
        {
            try
            {

				HaltMoveUtil();

            }
            catch (Exception ex)
            {
                doMoveButton.Enabled = true;
                HomeAxisButton.Enabled = true;
                DisplayError(ex);
            }
        }

        private void BasicMoves_FormClosing(object sender, FormClosingEventArgs e)
        {
            xAxisAmp.Disable();
            x2AxisAmp.Disable();
            yAxisAmp.Disable();

        }

        public void DisplayError(Exception ex)
        {
            DialogResult errormsgbox;
            errormsgbox = MessageBox.Show("Error Message: " + ex.Message + "\n" + "Error Source: "
                + ex.Source, "CMO Error", MessageBoxButtons.OKCancel);
            if (errormsgbox == DialogResult.Cancel)
            {
                // it is possible that this method was called from a thread other than the 
                // GUI thread - if this is the case we must use a delegate to close the application.
                //Dim d As New CloseApp(AddressOf ThreadSafeClose)
                CloseApp d = new CloseApp(ThreadSafeClose);
                this.Invoke(d);
            }
        }

        public void ThreadSafeClose()
        {
            //If the calling thread is different than the GUI thread, then use the
            //delegate to close the application, otherwise call close() directly
            if (this.InvokeRequired)
            {
                CloseApp d = new CloseApp(ThreadSafeClose);
                this.Invoke(d);
            }
            else
                Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DistanceTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void Modified_X_Textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void VelocityTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AccelTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        // Perform scan once
        private void button1_Click(object sender, EventArgs e)
        {
            U3_EFunctions a = new U3_EFunctions();
            a.performActions();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void X_StepTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void posTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void label26_Click(object sender, EventArgs e)
		{

		}

		private void y_postextbox_TextChanged(object sender, EventArgs e)
		{

		}


	}
}

