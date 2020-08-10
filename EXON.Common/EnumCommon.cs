using System;

namespace EXON.Common
{
    [Flags]
    public enum QuizTypeEnum { Regular, Audio, Fill, FillAudio, Essay, Speaking, Matching,ReWritting }
    public enum QuestionFormat { Html, RTF };
    public enum QuestionStatus { New, Accepted, Repair, Delete }

    //public enum ContestStatus { New, Accepted, Cancel, Done, RegisterDone, DuringNotTest, DuringHaveTest, DuringConTest }
    public enum ContestStatus
    {
        New,
        Accepted,
        RegisterDone,
        GenerateOriginalDone,
        ScheduleShiftDone,
        GenereateTestDone,
        PrepareTestDone,
        ContestDone,
        Cancel
    }
    public enum LoginStatus { Login, Logout, Close, None }

    public enum OriginalTestStatus { New, Accepted, Repair }

    public enum PositionEnum { NEW, ADMIN, TPKT, TLKT, TK, CNBM, GV, CBTN }

    public enum TaskStatusEnum { New, During, Over, Complete }

    public enum Register { Deleted, New, Receipted, Iscontestant }

    public enum ProcessStatus { New, OK, Cancel, Break }

    public enum TypeServer { Main, Local}

    public enum ActionFormResult { Not, Change }
    public enum IsQuizEnum { Quiz, Essay }
    public enum StatusDivisionShift { Status_Zero, STATUS_INIT, STATUS_GENTEST, STATUS_ATTENDANCE, STATUS_VERITY, STATUS_DECRYPT, STATUS_DIVISIONTEST, STATUS_STARTTEST, STATUS_COMPLETE, STATUS_PAUSE }

}