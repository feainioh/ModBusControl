using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Basler.Pylon;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace ECInspect
{
    class BaslerCCD
    {
        private Camera camera = null;
        private PixelDataConverter converter = new PixelDataConverter();
        private Stopwatch stopWatch = new Stopwatch();
        
        //状态
        internal delegate void dele_CCDStatusChanged(CCDStatus status);
        internal event dele_CCDStatusChanged Event_CCDStatusChanged;

        //抓取
        internal delegate void dele_CCDGrabChanged(CCDGrabStatus status);
        internal event dele_CCDGrabChanged Event_CCDGrabStatusChanged;

        //异常
        internal delegate void dele_ShowException(string err);
        internal event dele_ShowException Event_ShowException;

        private Logs log = Logs.LogsT();

        /// <summary>
        /// 相机状态
        /// </summary>
        internal string Status
        {
            get
            {
                if (camera != null)
                    return camera.IsConnected ? "连接" : "断开";
                else return "异常";
            }
        }

        /// <summary>
        /// 是否处于抓取图像中
        /// </summary>
        internal bool IsGrabing { get { return camera.StreamGrabber.IsGrabbing; } }

        public BaslerCCD(string serialNumber)
        {
            // Destroy the old camera object.
            if (camera != null)
            {
                DestroyCamera();
            }

            try
            {
                // Create a new camera object.
                camera = new Camera(serialNumber);

                camera.CameraOpened += Configuration.AcquireContinuous;

                // Register for the events of the image provider needed for proper operation.
                camera.ConnectionLost += OnConnectionLost;
                camera.CameraOpened += OnCameraOpened;
                camera.CameraClosed += OnCameraClosed;
                camera.StreamGrabber.GrabStarted += OnGrabStarted;
                camera.StreamGrabber.ImageGrabbed += OnImageGrabbed;
                camera.StreamGrabber.GrabStopped += OnGrabStopped;

                // Open the connection to the camera device.
                camera.Open();

                //// Set the parameter for the controls.
                //testImageControl.Parameter = camera.Parameters[PLCamera.TestImageSelector];
                //pixelFormatControl.Parameter = camera.Parameters[PLCamera.PixelFormat];
                //widthSliderControl.Parameter = camera.Parameters[PLCamera.Width];
                //heightSliderControl.Parameter = camera.Parameters[PLCamera.Height];
                //if (camera.Parameters.Contains(PLCamera.GainAbs))
                //{
                //    gainSliderControl.Parameter = camera.Parameters[PLCamera.GainAbs];
                //}
                //else
                //{
                //    gainSliderControl.Parameter = camera.Parameters[PLCamera.Gain];
                //}
                //if (camera.Parameters.Contains(PLCamera.ExposureTimeAbs))
                //{
                //    exposureTimeSliderControl.Parameter = camera.Parameters[PLCamera.ExposureTimeAbs];
                //}
                //else
                //{
                //    exposureTimeSliderControl.Parameter = camera.Parameters[PLCamera.ExposureTime];
                //}
            }
            catch (Exception exception)
            {
                ShowException(exception);
                //throw new Exception(exception.Message);
            }
        }

        // Occurs when a device with an opened connection is removed.
        private void OnConnectionLost(Object sender, EventArgs e)
        {
            CCDStatusChange(CCDStatus.ConnectionLost);
            //if (InvokeRequired)
            //{
            //    // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
            //    BeginInvoke(new EventHandler<EventArgs>(OnConnectionLost), sender, e);
            //    return;
            //}

            // Close the camera object.
            DestroyCamera();
            // Because one device is gone, the list needs to be updated.
            UpdateDeviceList();
        }


        // Occurs when the connection to a camera device is opened.
        private void OnCameraOpened(Object sender, EventArgs e)
        {
            CCDStatusChange(CCDStatus.CameraOpened);
            //if (InvokeRequired)
            //{
            //    // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
            //    BeginInvoke(new EventHandler<EventArgs>(OnCameraOpened), sender, e);
            //    return;
            //}

            // The image provider is ready to grab. Enable the grab buttons.
            //EnableButtons(true, false);
        }

        // Occurs when the connection to a camera device is closed.
        private void OnCameraClosed(Object sender, EventArgs e)
        {
            CCDStatusChange(CCDStatus.CameraClosed);
            //if (InvokeRequired)
            //{
            //    // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
            //    BeginInvoke(new EventHandler<EventArgs>(OnCameraClosed), sender, e);
            //    return;
            //}

            // The camera connection is closed. Disable all buttons.
            //EnableButtons(false, false);
        }


        // Occurs when a camera starts grabbing.
        private void OnGrabStarted(Object sender, EventArgs e)
        {
            CCDGrabStatusChange(CCDGrabStatus.Start);
            //if (InvokeRequired)
            //{
            //    // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
            //    BeginInvoke(new EventHandler<EventArgs>(OnGrabStarted), sender, e);
            //    return;
            //}

            // Reset the stopwatch used to reduce the amount of displayed images. The camera may acquire images faster than the images can be displayed.

            stopWatch.Reset();

            // The camera is grabbing. Disable the grab buttons. Enable the stop button.
            //EnableButtons(false, true);
        }


        // Occurs when an image has been acquired and is ready to be processed.
        private void OnImageGrabbed(Object sender, ImageGrabbedEventArgs e)
        {
            //if (InvokeRequired)
            //{
            //    // If called from a different thread, we must use the Invoke method to marshal the call to the proper GUI thread.
            //    // The grab result will be disposed after the event call. Clone the event arguments for marshaling to the GUI thread. 
            //    BeginInvoke(new EventHandler<ImageGrabbedEventArgs>(OnImageGrabbed), sender, e.Clone());
            //    return;
            //}

            try
            {
                // Acquire the image from the camera. Only show the latest image. The camera may acquire images faster than the images can be displayed.

                // Get the grab result.
                IGrabResult grabResult = e.GrabResult;

                // Check if the image can be displayed.
                if (grabResult.IsValid)
                {
                    // Reduce the number of displayed images to a reasonable amount if the camera is acquiring images very fast.
                    if (!stopWatch.IsRunning || stopWatch.ElapsedMilliseconds > 33)
                    {
                        stopWatch.Restart();

                        Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
                        // Lock the bits of the bitmap.
                        BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                        // Place the pointer to the buffer of the bitmap.
                        converter.OutputPixelFormat = PixelType.BGRA8packed;
                        IntPtr ptrBmp = bmpData.Scan0;
                        converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, grabResult); //Exception handling TODO
                        bitmap.UnlockBits(bmpData);

                        CCDImageGrab(bitmap);//显示抓取的图像
                        //// Assign a temporary variable to dispose the bitmap after assigning the new bitmap to the display control.
                        //Bitmap bitmapOld = pictureBox.Image as Bitmap;
                        //// Provide the display control with the new bitmap. This action automatically updates the display.
                        //pictureBox.Image = bitmap;
                        //if (bitmapOld != null)
                        //{
                        //    // Dispose the bitmap.
                        //    bitmapOld.Dispose();
                        //}
                    }
                }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
            finally
            {
                // Dispose the grab result if needed for returning it to the grab loop.
                e.DisposeGrabResultIfClone();
            }
        }


        // Occurs when a camera has stopped grabbing.
        private void OnGrabStopped(Object sender, GrabStopEventArgs e)
        {
            CCDGrabStatusChange(CCDGrabStatus.Stop);
            //if (InvokeRequired)
            //{
            //    // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
            //    BeginInvoke(new EventHandler<GrabStopEventArgs>(OnGrabStopped), sender, e);
            //    return;
            //}

            // Reset the stopwatch.
            stopWatch.Reset();

            // The camera stopped grabbing. Enable the grab buttons. Disable the stop button.
            //EnableButtons(true, false);

            // If the grabbed stop due to an error, display the error message.
            if (e.Reason != GrabStopReason.UserRequest)
            {
                Console.WriteLine("A grab error occured:\n" + e.ErrorMessage);
            }
        }

        // Stops the grabbing of images and handles exceptions.
        internal void Stop()
        {
            // Stop the grabbing.
            try
            {
                if (camera.IsConnected)
                    camera.StreamGrabber.Stop();
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }

        // Closes the camera object and handles exceptions.
        private void DestroyCamera()
        {
            // Disable all parameter controls.
            try
            {
                if (camera != null)
                {

                    //testImageControl.Parameter = null;
                    //pixelFormatControl.Parameter = null;
                    //widthSliderControl.Parameter = null;
                    //heightSliderControl.Parameter = null;
                    //gainSliderControl.Parameter = null;
                    //exposureTimeSliderControl.Parameter = null;
                }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }

            // Destroy the camera object.
            try
            {
                if (camera != null)
                {
                    camera.Close();
                    camera.Dispose();
                    camera = null;
                }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }

        // Starts the grabbing of a single image and handles exceptions.
        internal void OneShot()
        {
            try
            {
                // Starts the grabbing of one image.
                camera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.SingleFrame);
                camera.StreamGrabber.Start(1, GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }

        // Starts the continuous grabbing of images and handles exceptions.
        internal void ContinuousShot()
        {
            try
            {
                // Start the grabbing of images until grabbing is stopped.
                camera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.Continuous);
                camera.StreamGrabber.Start(GrabStrategy.LatestImages, GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }

        private void CCDStatusChange(CCDStatus status)
        {
            if (this.Event_CCDStatusChanged != null) this.Event_CCDStatusChanged(status);
        }

        private void CCDGrabStatusChange(CCDGrabStatus status)
        {
            if (this.Event_CCDGrabStatusChanged != null) this.Event_CCDGrabStatusChanged(status);
        }

        internal delegate void dele_ImageGrab(Bitmap e);
        internal event dele_ImageGrab Event_ImageGrab;

        private void CCDImageGrab(Bitmap e)
        {
            e.RotateFlip(RotateFlipType.Rotate180FlipNone);//旋转180度，不翻转
            if (this.Event_ImageGrab != null) this.Event_ImageGrab(e);
        }

        private void UpdateDeviceList()
        { 
        
        }

        private void ShowException(Exception ex)
        {
            Console.WriteLine("Basler Err:"+ex.Message);
            log.AddERRORLOG("Basler Err:" + ex.Message);

            if (this.Event_ShowException != null) this.Event_ShowException("CCD Err:" + ex.Message);
        }
    }
}
