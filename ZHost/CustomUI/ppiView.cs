using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ZHost
{
    public partial class ppiView : UserControl
    {
        #region Properties

        #region drawing-related items

        int borderGap = 5;
        int axisFntSize = 5;
        int boatSize = 22;
        int boatThickness = 10;
        int limboThickness = 10;
        int limboTickThickness = 5;
        int axisCircleThickness = 1;
        int axisCrossThickness = 1;
        int miscFntSize = 5;
        int targetSize = 5;

        float scaleFactor = 1.2f;

        Color axisCrossClr = Color.CadetBlue;
        Color axisTextClr = Color.CadetBlue;
        Color axisCircleClr = Color.CadetBlue;
        Color boatClr = Color.Yellow;
        Color limboClr = Color.CornflowerBlue;
        Color limboTickClr = Color.LightBlue;
        Color miscInfoClr = Color.Yellow;
        Color miscWarningClr = Color.OrangeRed;

        Color targetDistLineClr = Color.Yellow;
        Color targetCircleClr = Color.Yellow;
        Color targetIDClr = Color.Yellow;


        Pen boatPen;
        Pen axisCrossPen;
        Pen axisCirclePen;
        Pen limboPen;
        Pen limboTickPen;

        Pen targetDistLinePen;
        Pen targetCirclePen;

        Brush axisTextBrs;
        Brush backGroundBrs;
        Brush miscInfoBrs;
        Brush targetIDBrs;
        Brush miscWarningBrs;

        Font axisTextFnt;
        Font miscInfoFnt;

        Font targetIDFnt;

        StringFormat tFormat = new StringFormat();

        #endregion

        Dictionary<string, DrawTarget> targets;

        string leftUpperCornerText = string.Empty;
        public string LeftUpperCornerText
        {
            get { return leftUpperCornerText; }
            set { leftUpperCornerText = value; }
        }

        double heading = double.NaN;
        public double Heading
        {
            get { return heading; }
            set { heading = value; }
        }

        double ownLat = double.NaN;
        public double OwnLat
        {
            get { return ownLat; }
            set { ownLat = value; }
        }

        double ownLon = double.NaN;
        public double OwnLon
        {
            get { return ownLon; }
            set { ownLon = value; }
        }

        string leftBottomLine = string.Empty;
        public string LeftBottomLine
        {
            get { return leftBottomLine; }
            set { leftBottomLine = value; }
        }

        string rightTopLine = string.Empty;
        public string RightTopLine
        {
            get { return rightTopLine; }
            set { rightTopLine = value; }
        }
        
        #endregion

        #region Constructor

        public ppiView()
        {
            InitializeComponent();

            #region Misc

            targets = new Dictionary<string, DrawTarget>();

            #endregion

            #region drawing stuff

            axisCrossPen = new Pen(axisCrossClr, axisCrossThickness);
            axisTextFnt = new System.Drawing.Font("Consolas", axisFntSize, GraphicsUnit.Millimeter);

            axisTextBrs = new SolidBrush(axisTextClr);
            axisCirclePen = new Pen(axisCircleClr, axisCircleThickness);

            backGroundBrs = new SolidBrush(Color.Black);

            boatPen = new Pen(boatClr, boatThickness);
            boatPen.EndCap = System.Drawing.Drawing2D.LineCap.Triangle;

            limboPen = new Pen(limboClr, limboThickness);
            limboTickPen = new Pen(limboTickClr, limboTickThickness);
            limboTickPen.StartCap = System.Drawing.Drawing2D.LineCap.Triangle;

            miscInfoBrs = new SolidBrush(miscInfoClr);
            miscInfoFnt = new System.Drawing.Font("Consolas", miscFntSize, GraphicsUnit.Millimeter);
            miscWarningBrs = new SolidBrush(miscWarningClr);

            targetDistLinePen = new Pen(targetDistLineClr, 1);
            targetCirclePen = new Pen(targetCircleClr, 4);

            targetIDBrs = new SolidBrush(targetIDClr);
            targetIDFnt = new Font("Consolas", targetSize, GraphicsUnit.Millimeter);


            tFormat.LineAlignment = StringAlignment.Center;
            tFormat.Alignment = StringAlignment.Center;

            #endregion

            this.DoubleBuffered = true;            
            this.Resize += (o, e) => this.Invalidate();
        }

        #endregion

        #region Handlers

        private void ppiView_Paint(object sender, PaintEventArgs e)
        {
            if (e.ClipRectangle.IsEmpty)
                return;
          
            #region find maximum distance for scaling

            float maxDistance = 1.0f;
            foreach (var target in targets)
            {
                if (target.Value.Distance > maxDistance)
                    maxDistance = target.Value.Distance;
            }

            #endregion

            #region init

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            float width = this.Width;
            float height = this.Height;

            e.Graphics.TranslateTransform(width / 2.0f, height / 2.0f);

            float axisStep = 0;
            maxDistance = GetNearestRoundHlv(maxDistance, out axisStep);

            float scale = width;
            if (scale > height) scale = height;
            scale -= limboThickness * 5;
            scale /= 2 * (scaleFactor * maxDistance);
            float limboRadius = maxDistance * scaleFactor * scale;

            #endregion

            #region draw cross

            e.Graphics.DrawLine(axisCrossPen, -limboRadius, 0, limboRadius, 0);
            e.Graphics.DrawLine(axisCrossPen, 0, limboRadius, 0, -limboRadius);

            #endregion

            #region draw axis

            string rFStr = "F00";
            if (maxDistance <= 1) rFStr = "F01";
            float radius = axisStep;
            float rS = 0;
            do
            {
                rS = radius * scale;
                e.Graphics.DrawEllipse(axisCrossPen, -rS, -rS, rS * 2, rS * 2);

                var lblStr = radius.ToString(rFStr, CultureInfo.InvariantCulture);
                var lblSize = e.Graphics.MeasureString(lblStr, axisTextFnt);

                e.Graphics.FillRectangle(backGroundBrs, -lblSize.Width / 2, -rS - lblSize.Height, lblSize.Width, lblSize.Height);
                e.Graphics.DrawString(lblStr, axisTextFnt, axisTextBrs, -lblSize.Width / 2, -rS - lblSize.Height);
                radius += axisStep;
            }
            while (radius <= maxDistance);

            e.Graphics.DrawEllipse(limboPen, -limboRadius, -limboRadius, limboRadius * 2, limboRadius * 2);

            int startDegree = 0;
            for (int degree = startDegree; degree < 360; degree += 15)
            {

                float rd = (float)((degree - 90) * Math.PI / 180.0);
                float x1 = (float)((limboRadius - limboThickness / 2) * Math.Cos(rd));
                float y1 = (float)((limboRadius - limboThickness / 2) * Math.Sin(rd));
                float x2 = (float)((limboRadius + limboThickness / 2) * Math.Cos(rd));
                float y2 = (float)((limboRadius + limboThickness / 2) * Math.Sin(rd));

                e.Graphics.DrawLine(limboTickPen, x1, y1, x2, y2);
            }

            #endregion

            #region draw targets

            float tx, ty;

            foreach (var item in targets.Values)
            {
                if (item.Distance < 0)
                    radius = scale;
                else
                    radius = item.Distance * scale;

                tx = radius * (float)(Math.Cos((item.Azimuth - 90.0) * Math.PI / 180));
                ty = radius * (float)(Math.Sin((item.Azimuth - 90.0) * Math.PI / 180));

                var tLbl = item.ID.ToString();
                var tLblSize = e.Graphics.MeasureString(tLbl, targetIDFnt);
                var tLblMSize = Math.Max(tLblSize.Width, tLblSize.Height);

                var tR = new RectangleF(tx - tLblMSize / 2, ty - tLblMSize / 2, tLblMSize, tLblMSize);
              
                if (item.IsTimeout)
                {
                    targetDistLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    targetCirclePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                }
                else
                {
                    targetDistLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    targetCirclePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                }

                e.Graphics.DrawLine(targetDistLinePen, 0, 0, tx, ty);
                e.Graphics.DrawEllipse(targetCirclePen, tR);
                e.Graphics.FillEllipse(Brushes.Black, tR);
                e.Graphics.DrawString(tLbl, targetIDFnt, targetIDBrs, tR, tFormat);
            }

            #endregion

            #region draw additional info

            e.Graphics.DrawString(leftUpperCornerText, miscInfoFnt, miscInfoBrs, -width / 2 + borderGap, -height / 2 + borderGap);

            var leftBottomLblSize = e.Graphics.MeasureString(leftBottomLine, miscInfoFnt);
            e.Graphics.DrawString(leftBottomLine, miscInfoFnt, miscInfoBrs, -width / 2 + borderGap, height / 2 - borderGap - leftBottomLblSize.Height);

            var rightTopLblSize = e.Graphics.MeasureString(rightTopLine, miscInfoFnt);
            e.Graphics.DrawString(rightTopLine, miscInfoFnt, miscWarningBrs, width / 2 - borderGap - rightTopLblSize.Width, -height / 2 + borderGap);

            if (!double.IsNaN(heading))
            {
                string northSign = "N";
                var nsignSize = e.Graphics.MeasureString(northSign, miscInfoFnt);
                e.Graphics.DrawString(northSign, miscInfoFnt, Brushes.Yellow, -nsignSize.Width / 2, -height / 2);
            }

            #endregion

            #region draw boat

            float hdn = (float)heading + 90;

            float cv = (float)Math.Sin(hdn * Math.PI / 180.0);
            float sv = (float)Math.Cos(hdn * Math.PI / 180.0);
            float xBs = sv * boatSize / 2;
            float yBs = cv * boatSize / 2;
            float xBe = -sv * boatSize / 2;
            float yBe = -cv * boatSize / 2;

            e.Graphics.DrawLine(boatPen, xBs, yBs, xBe, yBe);

            #endregion       
        }

        #endregion

        #region Methods

        public void SetTarget(string id, double distance, double azimuth, bool isTimeout)
        {
            if (!targets.ContainsKey(id))
                targets.Add(id, new DrawTarget());

            targets[id].ID = id;
            targets[id].Distance = Convert.ToSingle(distance);
            targets[id].Azimuth = Convert.ToSingle(azimuth);
            targets[id].IsTimeout = isTimeout;
        }

        private float GetNearestRoundHlv(double value, out float step)
        {
            double pwr = Math.Truncate(Math.Log10(Math.Abs(value)));
            double limit = Math.Pow(10, pwr);

            int its = 0;
            while (limit < value)
            {
                limit += Math.Pow(10, pwr) / 2;
                its++;
            }

            step = (float)Math.Pow(10, pwr);

            if (its == 0)
                step /= 2;

            while (limit / step > 4)
                step *= 2;

            return Convert.ToSingle(limit);
        }
        
        #endregion
    }
}
