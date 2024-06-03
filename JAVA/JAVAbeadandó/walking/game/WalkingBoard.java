package walking.game;
import java.util.Arrays;

public class WalkingBoard {
    private int[][] tiles;
    private int x;
    private int y;
    public static final int BASE_TILE_SCORE = 3;

    // public int[][] getTiles(){
    //     return this.tiles.clone();
    // }public int[][] getTiles() {
    public int[][] getTiles() {
        int size = tiles.length;
        int[][] copy = new int[size][];
        for (int i = 0; i < size; i++) {
            copy[i] = Arrays.copyOf(tiles[i], tiles[i].length);
        }
        return copy;
    }
        

    public WalkingBoard(int size){
        this.tiles = new int[size][size];
        for(int i=0; i<size; i++){
            for(int j=0; j<size; j++){
                this.tiles[i][j]= this.BASE_TILE_SCORE;
            }
        }
        this.x = 0;
        this.y = 0;
    }
    public WalkingBoard(int[][] tiles)
    {
        int size1 = tiles.length;
        int size2 = tiles[0].length;
        int [][] cloneArr = tiles.clone();
        this.tiles = new int[size1][size2];
        
        for(int i=0; i<size1; i++){
            for(int j=0; j<size2; j++){
                this.tiles[i][j]= this.BASE_TILE_SCORE;
            }
        }
        for(int i=0; i<size1; i++){
            for(int j=0; j<size2; j++){
                if(tiles[i][j] > this.BASE_TILE_SCORE)
                {
                    this.tiles[i][j] = cloneArr[i][j];
                }
            }
        }
        this.x = 0;
        this.y = 0;
    }
    public int[] getPosition(){
        int[] out = {this.x,this.y};
        return out;
    }
    public boolean isValidPosition(int x, int y){
        int size1 = tiles.length;
        int size2 = tiles[0].length;
        return (x < size1 && y < size2 &&  x >= 0 && y >= 0);
    }
    public int getTile(int x, int y){
        if (isValidPosition(x, y)){
            return tiles[x][y];
        }
        else{
            throw new IllegalArgumentException("Invalid position");
        }
    }

    // I know that X in this case expresses the x-axis and not the y-axis in math logic, 
    // but for ease of understanding, code logic, and tests;so I chose to make it like this as arr[x][y] not arr[y][x] just as labels
    public static int getXStep(walking.game.util.Direction direction){
        switch (direction) {
            case UP:
                return -1;        
            case DOWN:
                return 1;        
            default:
                return 0;
        }
    }
    public static int getYStep(walking.game.util.Direction direction)
    {
        switch (direction) {
            case RIGHT:
                return 1;        
            case LEFT:
                return -1;        
            default:
                return 0;
        }
    }
    public int moveAndSet(walking.game.util.Direction dr, int value){
        int xMove = getXStep(dr) + this.x;
        int yMove = getYStep(dr) + this.y;
        
        if(!isValidPosition(xMove, yMove)){
            return 0;
        }
        this.x = xMove;
        this.y =  yMove;
        int result = tiles[this.x][this.y];
        tiles[this.x][this.y] = value;
        return result;
    }
}
