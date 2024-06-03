package race.car;
import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;

import java.beans.Transient;

import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;


public class SectorTimerTest {
    @Test 
    public void seemsGood(){
        int[] tmb = {1,2,3};
        SectorTimer sectorTimes = new SectorTimer(tmb);
        assertArrayEquals(tmb, sectorTimes.getSectorTime()); 
    }
    @Test 
    public void 
}
