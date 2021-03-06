using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom_Rating_Star_Control
{
    [ToolboxItem(false)]
    public partial class Star : Control
    {
        public delegate void ActiveEventHandler(object sender, EventArgs e);
        public delegate void HoverEventHandler(object sender, EventArgs e);

        public event ActiveEventHandler StarActive;
        public event HoverEventHandler StarMouseEnter;
        public event HoverEventHandler StarMouseLeave;

        #region Properties

        [Category("Layout"),
        Description("Size of single star."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int StarSize
        {
            get => starSize;
            set
            {
                if (value > 0)
                {
                    starSize = value;
                    Height = StarSize;
                    Invalidate();
                }
            }
        }
        public Color StarActiveBackColor
        {
            get => starActiveBackColor;
            set
            {
                starActiveBackColor = value;
                Invalidate();
            }
        }
        public Color StarHoverBackColor
        {
            get => starHoverBackColor;
            set => starHoverBackColor = value;
        }

        public bool Active
        {
            get => active;
            set => active = value;
        }
        public bool Hovering
        {
            get => hovering;
            set => hovering = value;
        }
        public readonly PointF[] StarPoints = new PointF[10];

        #endregion

        public Star(MyStarRatingBar RatingBar)
        {
            this.RatingBar = RatingBar;

            StarActive += new ActiveEventHandler(RatingBar.star_StarActive);
            StarMouseEnter += new HoverEventHandler(RatingBar.star_MouseEnter);
            StarMouseLeave += new HoverEventHandler(RatingBar.star_MouseLeave);

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            Brush fillBrush;
            Pen pen = new(Color.Black, 2.5f);

            if (hovering)
            {
                fillBrush = new SolidBrush(StarHoverBackColor);
            }
            else if(!hovering && active)
            {
                fillBrush = new SolidBrush(StarActiveBackColor);
            }
            else
            {
                fillBrush = new SolidBrush(BackColor);
            }

            StarPoints[0].X = StarSize * (50) / 100;
            StarPoints[0].Y = StarSize * (2.4472f) / 100;
            StarPoints[1].X = StarSize * (61.8044f) / 100;
            StarPoints[1].Y = StarSize * (38.7743f) / 100;
            StarPoints[2].X = StarSize * (100) / 100;
            StarPoints[2].Y = StarSize * (38.7743f) / 100;
            StarPoints[3].X = StarSize * (69.0983f) / 100;
            StarPoints[3].Y = StarSize * (61.2257f) / 100;
            StarPoints[4].X = StarSize * (80.9843f) / 100;
            StarPoints[4].Y = StarSize * (97.5528f) / 100;
            StarPoints[5].X = StarSize * (50) / 100;
            StarPoints[5].Y = StarSize * (75.1014f) / 100;
            StarPoints[6].X = StarSize * (19.0983f) / 100;
            StarPoints[6].Y = StarSize * (97.5528f) / 100;
            StarPoints[7].X = StarSize * (30.9017f) / 100;
            StarPoints[7].Y = StarSize * (61.2257f) / 100;
            StarPoints[8].X = StarSize * (0) / 100;
            StarPoints[8].Y = StarSize * (38.7743f) / 100;
            StarPoints[9].X = StarSize * (38.1966f) / 100;
            StarPoints[9].Y = StarSize * (38.7743f) / 100;

            pe.Graphics.FillPolygon(fillBrush, StarPoints);
            pe.Graphics.DrawPolygon(pen, StarPoints);
            base.OnPaint(pe);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            hovering = true;
            StarMouseEnter(this, new EventArgs());
            Invalidate();

            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            hovering = false;
            StarMouseLeave(this, new EventArgs());
            Invalidate();

            base.OnMouseLeave(e);
        }
        protected override void OnClick(EventArgs e)
        {
            active = true;
            StarActive(this, new EventArgs());
            Invalidate();

            base.OnClick(e);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            StarSize = Size.Height;

            Width = StarSize;

            base.OnSizeChanged(e);
        }

        #region Protected Data

        protected MyStarRatingBar RatingBar;
        protected int starSize = 50;
        protected bool hovering = false;
        protected bool active = false;
        protected Color starActiveBackColor = Color.DarkBlue;
        protected Color starHoverBackColor = Color.Yellow;

        #endregion
    }
}
