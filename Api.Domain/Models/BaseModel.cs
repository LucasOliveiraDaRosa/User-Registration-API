using System;

namespace Domain.Models
{
    public class BaseModel
    {
        private Guid guid;

        public Guid Id
        {
            get { return guid; }
            set { guid = value; }
        }

        private DateTime _CreateAt;

        public DateTime CreateAt
        {
            get { return _CreateAt; }
            set
            {
                _CreateAt = value == null ? DateTime.UtcNow : value;
            }
        }

        private DateTime _updateAt;

        public DateTime UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }
    }
}
