@ParameterizedTest(name="helloWrld")
@CsvSource(textBlock="""
            2, 3, 32
            43, 43, 34
            3, 32 ,12
            """)
@DisableIFHasBadStructure 
public void valami(int i, int j, int l){

}

@Test 
public void valami2(){
    fail
}


implements vmi.inftr , Comparable<Shape>{


    public boolean equals(Object othr){
        if(this == othr){return true;}
        if(othr instanceof Shape shp){
            return Arrays.compare(this.valmi, othr.valami);

        }
    }
    public int compareTo(Shape two){
        int minV = this.valmi - two.valmi;
        if(minV != 0) return minv;
        for(int i = 0; i < x.lenght; i++){
            if(this.valami[i] - two.valami[i] !=0){
                return this.valami[i] - two.valami[i];
            }
        }
        return 0;
    }
}