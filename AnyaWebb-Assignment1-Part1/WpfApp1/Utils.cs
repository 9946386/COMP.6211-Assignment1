using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;

namespace AnyaWebbAssignment1
{
    public static class Utils
    {
        public static void MoveWithTriggers(Image anImage, bool left, bool right, bool top, bool bottom, double speed)
        {
            //Find location of object
            double leftMargin = anImage.Margin.Left;
            double topMargin = anImage.Margin.Top;
            double rightMargin = anImage.Margin.Right;
            double bottomMargin = anImage.Margin.Bottom;
            
            //Set the move direction
            if (left == true) leftMargin = leftMargin - speed;
            if (right == true) leftMargin = leftMargin + speed;
            if (top == true) topMargin = topMargin - speed;
            if (bottom == true) topMargin = topMargin + speed;

            //Reset image
            anImage.Margin = new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);
        }

        public static void AutoMovement(Image anImage, Grid aGrid, ref bool testFlagX, ref bool testFlagY)
        {
            //Find the location of the object
            double leftMargin = anImage.Margin.Left;
            double topMargin = anImage.Margin.Top;
            double rightMargin = anImage.Margin.Right;
            double bottomMargin = anImage.Margin.Bottom;

            // Set the move direction
            if (testFlagX == true) leftMargin = leftMargin - 2;
            if (testFlagX == false) leftMargin = leftMargin + 2;
            if (testFlagY == true) topMargin = topMargin - 2;
            if (testFlagY == false) topMargin = topMargin + 2;

            if (leftMargin <= 0) //Stop at left and bounce back
            {
                leftMargin = 0;
                testFlagX = false;
            }

            if ((leftMargin + anImage.Width) > aGrid.Width) //Stop at right side and bounce back
            {
                leftMargin = aGrid.Width - anImage.Width;
                testFlagX = true;
            }

            if ((topMargin + anImage.Height) > aGrid.Height) //Stop at bottom and bounce back
            {
                topMargin = aGrid.Height - anImage.Height;
                testFlagY = true;
            }

            if (topMargin <= 0) //Stop at top and bounce back
            {
                topMargin = 0;
                testFlagY = false;
            }

            //Reset
            anImage.Margin = new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);
        }

        public static void LockToGrid(Image anImage, Grid aGrid)
        {
            //Find location of object
            double leftMargin = anImage.Margin.Left;
            double topMargin = anImage.Margin.Top;
            double rightMargin = anImage.Margin.Right;
            double bottomMargin = anImage.Margin.Bottom;

            //Lock the image to the background/grid
            if ((leftMargin + anImage.Width) > aGrid.Width) leftMargin = aGrid.Width - anImage.Width; //Right side
            if (leftMargin <= 0) leftMargin = 0; //Left side
            if ((topMargin + anImage.Height) > aGrid.Height) topMargin = aGrid.Height - anImage.Height; //Bottom
            if (topMargin <= 0) topMargin = 0; //Top 

            //Reset
            anImage.Margin = new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);
        }

        public static void Follow(Image image1, Image image2, double speed)
        {
            //Find location of image one / leader
            double image1leftMargin = image1.Margin.Left;
            double image1topMargin = image1.Margin.Top;
            double image1rightMargin = image1.Margin.Right;
            double image1bottomMargin = image1.Margin.Bottom;

            //Find location of image two / follower
            double image2leftMargin = image2.Margin.Left;
            double image2topMargin = image2.Margin.Top;
            double image2rightMargin = image2.Margin.Right;
            double image2bottomMargin = image2.Margin.Bottom;

            //If the followers left margin is lower than leaders left margin increment movement.
            if (image2leftMargin < image1leftMargin)
            {
                image2leftMargin += speed;
            }

            //If the followers left margin is higher than leaders left margin decrement movement.
            if (image2leftMargin > image1leftMargin)
            {
                image2leftMargin -= speed;
            }

            //If the followers left margin is lower than leaders left margin increment movement.
            if (image2topMargin < image1topMargin)
            {
                image2topMargin += speed;
            }

            //If the followers left margin is higher than leaders left margin increment movement.
            if (image2topMargin > image1topMargin)
            {
                image2topMargin -= speed;
            }

            //Reset
            image2.Margin = new Thickness(image2leftMargin, image2topMargin, image2rightMargin, image2bottomMargin);
        }

        public static void Runaway(Image image1, Image image2, ref bool testFlagX, ref bool testFlagY, Grid aGrid)
        {
            //Find location of image one 
            double image1leftMargin = image1.Margin.Left;
            double image1topMargin = image1.Margin.Top;
            double image1rightMargin = image1.Margin.Right;
            double image1bottomMargin = image1.Margin.Bottom;

            //Find location of image two / run away image
            double image2leftMargin = image2.Margin.Left;
            double image2topMargin = image2.Margin.Top;
            double image2rightMargin = image2.Margin.Right;
            double image2bottomMargin = image2.Margin.Bottom;

            //Moving the location
            if (testFlagX == true) image2leftMargin = image2leftMargin - 2;
            if (testFlagX == false) image2leftMargin = image2leftMargin + 2;
            if (testFlagY == true) image2topMargin = image2topMargin - 2;
            if (testFlagY == false) image2topMargin = image2topMargin + 2;

            #region Lock to grid
            // Lock image 2 to grid
            if ((image2leftMargin + image2.Width) > aGrid.Width) //Right side
            {
                image2leftMargin = aGrid.Width - image2.Width;
                testFlagX = true;
            }

            if (image2leftMargin <= 0) //Left side
            {
                image2leftMargin = 0;
                testFlagX = false;
            }

            if ((image2topMargin + image2.Height) > aGrid.Height) //Bottom
            {
                image2topMargin = aGrid.Height - image2.Height;
                testFlagY = true;
            }

            if (image2topMargin <= 0) //Top 
            {
                image2topMargin = 0;
                testFlagY = false;
            }
            #endregion

            #region Run away

            if (image2leftMargin > (image1leftMargin + image1.Width)) // Right - Runaway
            {
                image2leftMargin += 1;
            }

            if (image2leftMargin < image1leftMargin) //Left - Runaway
            {
                image2leftMargin -= 1;
            }

            if (image2topMargin < image1topMargin) // Top - Runaway
            {
                image2topMargin -= 1;
            }

            if (image2topMargin > (image1topMargin + image1.Height)) // Bottom - Runaway
            {
                image2topMargin += 1;
            }

            //Reset
            image2.Margin = new Thickness(image2leftMargin, image2topMargin, image2rightMargin, image2bottomMargin);
            image1.Margin = new Thickness(image1leftMargin, image1topMargin, image1rightMargin, image1bottomMargin);

            #endregion
        }

        public static void Collide(Image image1, Image image2, ref bool testFlagX, ref bool testFlagY, Grid aGrid, int speed)
        {
            //Find location of image one 
            double image1leftMargin = image1.Margin.Left;
            double image1topMargin = image1.Margin.Top;
            double image1rightMargin = image1.Margin.Right;
            double image1bottomMargin = image1.Margin.Bottom;

            //Find location of image two / run away image
            double image2leftMargin = image2.Margin.Left;
            double image2topMargin = image2.Margin.Top;
            double image2rightMargin = image2.Margin.Right;
            double image2bottomMargin = image2.Margin.Bottom;

            //Moving image2 location - Only needed if collision is commented out.
            if (testFlagX == true) image2leftMargin = image2leftMargin - speed;
            if (testFlagX == false) image2leftMargin = image2leftMargin + speed;
            if (testFlagY == true) image2topMargin = image2topMargin - speed;
            if (testFlagY == false) image2topMargin = image2topMargin + speed;

            #region Lock to grid
            // Lock image 2 to grid - Only needed if collision is commented out.
            if ((image2leftMargin + image2.Width) > aGrid.Width) //Right side
            {
                image2leftMargin = aGrid.Width - image2.Width;
                testFlagX = true;
            }

            if (image2leftMargin <= 0) //Left side
            {
                image2leftMargin = 0;
                testFlagX = false;
            }

            if ((image2topMargin + image2.Height) > aGrid.Height) //Bottom
            {
                image2topMargin = aGrid.Height - image2.Height;
                testFlagY = true;
            }

            if (image2topMargin <= 0) //Top 
            {
                image2topMargin = 0;
                testFlagY = false;
            }
            #endregion

            //If image 2 collides with image 1
            if ((image2leftMargin + image2.Width) > image1leftMargin &&
                image2leftMargin < (image1leftMargin + image1.Width) &&
                (image2topMargin + image2.Height) > image1topMargin &&
                image2topMargin < (image1topMargin + image1.Height))
            {
                //Make image 2 smaller
                image2.Width -= .8;
                image2.Height -= .8;
            }

            //If not make image 2 slowly get bigger
            else
            {
                image2.Width += .2;
                image2.Height += .2;
            }

            //Reset
            image2.Margin = new Thickness(image2leftMargin, image2topMargin, image2rightMargin, image2bottomMargin);
            image1.Margin = new Thickness(image1leftMargin, image1topMargin, image1rightMargin, image1bottomMargin);
        }

    }
}
