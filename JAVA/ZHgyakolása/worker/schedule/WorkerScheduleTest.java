package worker.schedule;
import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;
import java.io.*;
import java.util.*;
public class WorkerScheduleTest {

    @Test
    public void emptySchedule() {
        worker.schedule.WorkerSchedule ws = new worker.schedule.WorkerSchedule();
        assertFalse(ws.isWorkingOnWeek("Mota", 3));
    }

    @ParameterizedTest(name="2ndTst")
    @CsvSource(textBlock="""
            2, "Ketto" 
            4, "negy"  
            6, "hat"
        """)
    
    @DisableIfHasBadStructure
    public void schedule(int n, String str){
        worker.schedule.WorkerSchedule wSc = new worker.schedule.WorkerSchedule();
        HashSet<String> hs = new HashSet<String>();
        hs.add(str);
        wSc.add(n,hs);
        assertTrue( wSc.isWorkingOnWeek(str,n));
        HashSet<Integer> hi = new HashSet<Integer>();
        hi.add(n);
        assertEquals(hi,wSc.getWorkWeeks(str));

        ArrayList<String> al = new ArrayList<>(List.of("Rami","Laden","Robaa"));
        HashSet<Integer> weeks = new HashSet<Integer>();
        weeks.add(3);
        weeks.add(2);
        weeks.add(1);
        weeks.add(4);
        wSc = new worker.schedule.WorkerSchedule();
        wSc.add(weeks,al);
        assertTrue(wSc.isWorkingOnWeek("Rami",3));
        
    }
}