package worker.schedule;
import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;

import java.util.HashSet;

public class WorkerScheduleTest {
    @Test 
    public void testWorkerSchedule(){
        WorkerSchedule ws = new WorkerSchedule();
        HashSet<String> jams = new HashSet<String>();
        jams.add("james");
        ws.add(5, jams);
        assertEquals(true , ws.isWorkingOnWeek("james", 5));
        assertTrue(ws.isWorkingOnWeek("james", 5));
        assertFalse(ws.isWorkingOnWeek("james", 35));
        assertFalse(ws.isWorkingOnWeek("jmes", 53));
    }
    @Test 
    public void tes22t(){
        WorkerSchedule ws = new WorkerSchedule();
        HashSet<String> jams = new HashSet<String>();
        jams.add("james");
        ws.add(1, jams);
        ws.add(2, jams);
        ws.add(3, jams);
        ws.add(4, jams);
        ws.add(5, jams);
        
        HashSet<Integer> output = new HashSet<>();
        output.add(1);
        output.add(2);
        output.add(3);
        output.add(4);
        output.add(5);
        
        assertEquals(output , ws.getWorkWeeks("james"));
    }
    @Test 
    public void testAddKX(){
        WorkerSchedule ws = new WorkerSchedule();
        HashSet<String> workers = new HashSet<String>();
        

    }

}
