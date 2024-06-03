package race.car;

public class SectorTimer {
    private int[] sectorTimes;
    public int[] getSectorTimes(){
        return sectorTimes.clone();
    }
    public SectorTimer(int[] x){
        this.sectorTimes = x.clone();
    }
    public SectorTimer(boolean b,int[] x){
        this.sectorTimes = x.clone();

    }

    public int[] getSectorTime(){
        return sectorTimes.clone();
    }
    public int getSectorTime(int n){
        return sectorTimes[n];
    }
    public int[]  getSectorTimesV2(){
        return sectorTimes.clone();
    }
    private void initSectorTimes(int[] x){
        
        sectorTimes = x;
    }
    public void setLapTimes(int[] x){
        sectorTimes = x;
    }
    public void setSectorTimesV2(int[] x){
        sectorTimes = x;
    }
}
