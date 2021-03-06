﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnyaWebbAssignment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Movement flags   
        bool testFlag1X = true;
        bool testFlag1Y = true;

        bool testFlag2X = true;
        bool testFlag2Y = true;

        #endregion

        #region Key Press Flags
        bool flagA = false;
        bool flagD = false;
        bool flagW = false;
        bool flagS = false;
        #endregion

        #region Random Element
        //Used to randomly select image3 speed
        Random randy = new Random();
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            //Set game loop timer
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(10000);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //Setting image3 random speed to be between 0 and 6
            int speed = randy.Next(0, 6);

            #region Move with triggers
            //Not needed if auto movement is on
            //Utils.MoveWithTriggers(jerry, flagA, flagD, flagW, flagS, 5.00);
            #endregion

            #region Auto movement
            //Calling the auto movement method
            Utils.AutoMovement(jerry, background, ref testFlag1X, ref testFlag1Y);
            #endregion

            #region Lock to grid
            //Calling the lock to grid method
            Utils.LockToGrid(jerry, background);
            #endregion

            #region Follow
            //Calling the follow method
            Utils.Follow(jerry, tom, 1);
            #endregion

            #region Runaway
            //Calling the runaway method
            //Needs to be commented out for Collision to work
            //Utils.Runaway(jerry, spike, ref testFlag2X, ref testFlag2Y, background);
            #endregion

            #region Collision
            //Calling the collision method
            //Needs to be commented out for Runaway to work properly
            Utils.Collide(jerry, spike, ref testFlag2X, ref testFlag2Y, background, speed);
            #endregion
        }

        #region Change size of window
        private void TestWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            background.Width = window.Width - 30;
            background.Height = window.Height - 50;
        }
        #endregion

        #region Key Pressed test

        private void TestWindow_KeyDown(object sender, KeyEventArgs e)
        {
            flagA = false;
            flagD = false;
            flagW = false;
            flagS = false;

            if (e.Key == Key.A) flagA = true;
            if (e.Key == Key.D) flagD = true;
            if (e.Key == Key.W) flagW = true;
            if (e.Key == Key.S) flagS = true;
        }

        #endregion2
    }
}
