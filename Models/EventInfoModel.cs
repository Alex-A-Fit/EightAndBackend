namespace EightAnd_Backend.Models
{
    public class EventInfoModel
    {
        public int Id { get; set; }
        public int GroupId {get; set;}
        public string GroupName { get; set; }
        public string Location { get; set; }
        public string EventName { get; set; }
        public string EventDate { get; set; } 
        public string EventTime { get; set; } 
        public int NumOfPerformers { get; set; }
        public string DeadlineToAcceptDate  { get; set; }

        public string Description { get; set; }

        public bool PendingEvent { get; set; }
        public bool ConfirmEvent { get; set; }

        public EventInfoModel(){}

        public EventInfoModel(
            int id, 
            int groupId, 
            string groupName, 
            string location, 
            string eventName, 
            string eventDate, 
            string eventTime,
            int numOfPerformers, 
            string deadlineToAcceptDate, 
            string description, 
            bool pendingEvent,
            bool confirmEvent 
            )
        {
            Id = id;
            GroupId = groupId;
            GroupName = groupName;
            Location = location;
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            NumOfPerformers = numOfPerformers;
            DeadlineToAcceptDate = deadlineToAcceptDate;
            Description = description;
            PendingEvent = pendingEvent;
            ConfirmEvent = confirmEvent;
        }
    }

}