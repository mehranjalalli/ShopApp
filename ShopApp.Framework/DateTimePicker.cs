using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ShopApp.Framework
{
    public partial class DateTimePicker : UserControl
    {
        public event EventHandler OnSelectedDateChanged;
        public event EventHandler OnDateDoubleClick;

        int currentYear = 0;
        int currentMonth = 0;
        public DateTime SelectedDate { get; set; }

        public DateTimePicker()
        {
            InitializeComponent();
            CalendarGridView.CurrentCellChanged += CalendarGridView_CurrentCellChanged;
            CalendarGridView.CellDoubleClick += CalendarGridView_CellDoubleClick;
            SelectedDate = DateTime.Now;
        }

        private void CalendarGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OnDateDoubleClick != null)
                OnDateDoubleClick(this, new EventArgs());
        }

        private void CalendarGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (CalendarGridView.CurrentCell != null && CalendarGridView.CurrentCell.Tag != null)
            {
                SelectedDate = ((DateTime)CalendarGridView.CurrentCell.Tag);
                SelectedDateLabel.Text = ((DateTime)CalendarGridView.CurrentCell.Tag).ToString("dd MMM yyyy");
                OnSelectedDateChanged?.Invoke(this, new EventArgs());
            }
        }

        private void FillGridDays(int year, int month)
        {
            CalendarGridView.Rows.Clear();

            currentYear = year;
            currentMonth = month;            
            var calendar = new PersianCalendar();
            CurrentCalendarLabel.Text = new DateTime(year, month, 1, calendar).ToString("MMM yyyy");
            var todayMonthDay = calendar.GetDayOfMonth(DateTime.Now);
            var todayYear = calendar.GetYear(DateTime.Now);
            var todayMonth = calendar.GetMonth(DateTime.Now);
            var lastMonthDays = month == 1 ? calendar.GetDaysInMonth(year - 1, 12) : calendar.GetDaysInMonth(year, month - 1);
            var currentMonthDays = calendar.GetDaysInMonth(year, month);
            var firstDayOfWeek = calendar.GetDayOfWeek(new DateTime(year, month, 1, calendar));
            var firstDayOfWeekIndex = 0;
            if (firstDayOfWeek == DayOfWeek.Saturday)
                firstDayOfWeekIndex = 0;
            else
                firstDayOfWeekIndex = (int)firstDayOfWeek + 1;

            var rowIndex = 0;
            var cellIndex = 0;
            CalendarGridView.Rows.Add(1);

            var lastMonthStartDate = (lastMonthDays - firstDayOfWeekIndex) + 1;
            
            for (int dayIndex = lastMonthStartDate; dayIndex <= lastMonthDays; dayIndex++)
            {

                CalendarGridView.Rows[rowIndex].Cells[cellIndex].Tag = new DateTime(month == 1 ? year - 1 : year, month == 1 ? 12 : month - 1, dayIndex, calendar);
                CalendarGridView.Rows[rowIndex].Cells[cellIndex].Value = dayIndex;
                CalendarGridView.Rows[rowIndex].Cells[cellIndex++].Style.ForeColor = Color.Gainsboro;
            }

            bool selectedDateExists = false;
            for(int dayIndex = 1; dayIndex <= currentMonthDays; dayIndex++)
            {
                CalendarGridView.Rows[rowIndex].Cells[cellIndex].Value = dayIndex;
                CalendarGridView.Rows[rowIndex].Cells[cellIndex].Tag = new DateTime(year, month, dayIndex, calendar);
                var currentCellDate = new DateTime(year, month, dayIndex, calendar);
                if (dayIndex == todayMonthDay && month == todayMonth && year == todayYear)
                {
                    CalendarGridView.Rows[rowIndex].Cells[cellIndex].Style.BackColor = Color.DarkGreen;
                    CalendarGridView.Rows[rowIndex].Cells[cellIndex].Style.ForeColor = Color.White;                    
                }
                if (currentCellDate.Year == SelectedDate.Year && currentCellDate.Month == SelectedDate.Month && currentCellDate.Day == SelectedDate.Day)
                {
                    OnSelectedDateChanged?.Invoke(this, new EventArgs());
                    CalendarGridView.Rows[rowIndex].Cells[cellIndex].Selected = selectedDateExists = true;
                }
                cellIndex++;
                if (cellIndex > 6)
                {
                    cellIndex = 0;
                    rowIndex++;
                    CalendarGridView.Rows.Add(1);
                }
            }
            var nextMonthDay = 1;
            if (cellIndex > 0)
            {
                for (int dayIndex = cellIndex; dayIndex <= 6; dayIndex++)
                {
                    CalendarGridView.Rows[rowIndex].Cells[cellIndex].Tag = new DateTime(month == 12 ? year + 1 : year, month == 12 ? 1 : month + 1, dayIndex, calendar);
                    CalendarGridView.Rows[rowIndex].Cells[cellIndex].Value = nextMonthDay++;
                    CalendarGridView.Rows[rowIndex].Cells[cellIndex++].Style.ForeColor = Color.Gainsboro;
                }
            }
            foreach(var row in CalendarGridView.Rows.OfType<DataGridViewRow>())
            {
                row.Height = 50;
            }
            if (!selectedDateExists)
                CalendarGridView.CurrentCell = null;
        }

        private void DateTimePicker_Load(object sender, EventArgs e)
        {
            var calendar = new PersianCalendar();
            FillGridDays(calendar.GetYear(SelectedDate), calendar.GetMonth(SelectedDate));
        }

        private void NextYearButton_Click(object sender, EventArgs e)
        {
            FillGridDays(currentYear + 1, currentMonth);
        }

        private void LastYearButton_Click(object sender, EventArgs e)
        {
            FillGridDays(currentYear - 1, currentMonth);
        }

        private void NextMonthButton_Click(object sender, EventArgs e)
        {
            FillGridDays(currentMonth == 12 ? currentYear + 1 : currentYear, currentMonth == 12 ? 1 : currentMonth + 1);
        }

        private void LastMonthButton_Click(object sender, EventArgs e)
        {
            FillGridDays(currentMonth == 1 ? currentYear - 1 : currentYear, currentMonth == 1 ? 12 : currentMonth - 1);
        }

        private void GotoSelectedDateButton_Click(object sender, EventArgs e)
        {
            var calendar = new PersianCalendar();
            FillGridDays(calendar.GetYear(SelectedDate), calendar.GetMonth(SelectedDate));
        }

        private void GotoTodayButton_Click(object sender, EventArgs e)
        {
            var calendar = new PersianCalendar();
            FillGridDays(calendar.GetYear(DateTime.Now), calendar.GetMonth(DateTime.Now));
        }
    }
}
