from random import *
from tkinter import *
import time


root = Tk()
frame_main = Frame(root)
frame_main.pack()
root.geometry('1000x1000')

canvas = Canvas(frame_main, width=1000, height=1000)
canvas.create_rectangle(500, 500, 550, 550, fill = 'white')
canvas.create_rectangle(502, 502, 548, 548, fill = 'black')
canvas.pack()
canvas.update()

board = []
for i in range(10):
    board.append([0]*10)
board [4] [4] = 1



def draw_cell (x, y):
    canvas.create_rectangle(x, y, x+50, y+50, fill = 'white')
    canvas.create_rectangle(x+2, y+2, x+48, y+48, fill = 'black')

def draw_cellR (x, y):
    canvas.create_rectangle(x, y, x+50, y+50, fill = 'white')
    canvas.create_rectangle(x+2, y+2, x+48, y+48, fill = 'red')





nb_salle = 1

def generation (nb_salle, x, y, a ,b):
    nb_salle +=1
    print("new gen")
    if nb_salle >= 10:
        return
    
    canvas.update()
    if a-1 >=0 and board [a-1] [b] == 0 and nb_salle < 10:
        is_gen = randint(0,1)
        if is_gen == 1:
            draw_cell(x-50, y)
            board [a-1] [b] = 1
            nb_salle += 1
            
    if b+1 < 10 and board [a] [b+1] == 0 and nb_salle < 10:
        is_gen = randint(0,1)
        if is_gen == 1:
            draw_cell(x, y+50)
            board [a] [b+1] = 1
            nb_salle += 1
            
    if a+1 < 10 and board [a+1] [b] == 0 and nb_salle < 10:
        is_gen = randint(0,1)
        if is_gen == 1:
            draw_cell(x+50, y)
            board [a+1] [b] = 1
            nb_salle += 1
            
    if b-1 >= 0 and board [a] [b-1] == 0 and nb_salle < 10:
        is_gen = randint(0,1)
        if is_gen == 1:
            draw_cell(x, y-50)
            board [a] [b-1] = 1
            nb_salle += 1
            
            
    if (board[a-1][b], board[a][b+1], board[a+1][b], board[a][b-1]) == (1,1,1,1) and nb_salle < 10:
        draw_cellR(x-50,y-50)
        board [a-1] [b-1] = 2
        draw_cellR(x-50,y+50)
        board [a-1] [b+1] = 2
        draw_cellR(x+50,y-50)
        board [a+1] [b-1] = 2
        draw_cellR(x+50,y+50)
        board [a+1] [b+1] = 2
        generation (nb_salle+1, x-50, y, a-1, b)
        generation (nb_salle+1, x, y+50, a, b+1)
        generation (nb_salle+1, x+50, y, a+1, b)
        generation (nb_salle+1, x, y-50, a, b-1)

    if (board[a-1][b], board[a][b+1], board[a+1][b], board[a][b-1]) == (0,0,0,0) and nb_salle < 10:
        print("no room")
        generation (nb_salle+1, x, y, a, b)

    if (board[a][b-1]) == (1) and board[a][b+1] != 1 and board[a-1][b] != 1 and board[a+1][b] and nb_salle < 10:
        print("1 T")
        generation (nb_salle+1, x, y-50, a, b-1)
        
    if (board[a+1][b]) == (1) and board[a-1][b] != 1 and board[a][b+1] != 1 and board[a][b-1] and nb_salle < 10:
        print("1 R")
        generation (nb_salle+1, x+50, y, a+1, b)

    if (board[a][b+1]) == (1) and board[a][b-1] != 1 and board[a+1][b] != 1 and board[a-1][b] and nb_salle < 10:
        print("1 B")
        generation (nb_salle+1, x, y+50, a, b+1)

    if (board[a-1][b]) == (1) and board[a][b-1] != 1 and board[a][b+1] != 1 and board[a+1][b] and nb_salle < 10:
        print("1 L")
        generation (nb_salle+1, x-50, y, a-1, b)

    if (board[a+1][b], board[a][b-1]) == (1,1) and board[a-1][b] != 1 and board[a][b+1] != 1 and nb_salle < 10:
        print("2 T R")
        board [a+1] [b-1] = 2
        draw_cellR(x+50,y-50)
        generation (nb_salle+1, x, y-50, a, b-1)
        generation (nb_salle+1, x+50, y, a+1, b)

    if (board[a][b+1], board[a][b-1]) == (1,1) and board[a+1][b] != 1 and board[a-1][b] != 1 and nb_salle < 10:
        print("2 T B")
        generation (nb_salle+1, x, y-50, a, b-1)
        generation (nb_salle+1, x, y+50, a, b+1)

    if (board[a-1][b], board[a][b-1]) == (1,1) and board[a+1][b] != 1 and board[a][b+1] != 1 and nb_salle < 10:
        print("2 T L")
        board [a-1] [b-1] = 2
        draw_cellR(x-50,y-50)
        generation (nb_salle+1, x, y-50, a, b-1)
        generation (nb_salle+1, x-50, y, a-1, b)

    if (board[a][b+1], board[a+1][b]) == (1,1) and board[a-1][b] != 1 and board[a][b-1] != 1 and nb_salle < 10:
        print("2 B R")
        board [a+1] [b+1] = 2
        draw_cellR(x+50,y+50)
        generation (nb_salle+1, x, y+50, a, b+1)
        generation (nb_salle+1, x+50, y, a+1, b)

    if (board[a-1][b], board[a+1][b]) == (1,1) and board[a][b-1] != 1 and board[a][b+1] != 1 and nb_salle < 10:
        print("2 L R")
        generation (nb_salle+1, x-50, y, a-1, b)
        generation (nb_salle+1, x+50, y, a+1, b)

    if (board[a][b+1], board[a+1][b], board[a][b-1]) == (1,1,1) and board[a-1][b] != 1 and nb_salle < 10:
        print("3 B R T")
        board [a+1] [b-1] = 2
        draw_cellR(x+50,y-50)
        board [a+1] [b+1] = 2
        draw_cellR(x+50,y+50)
        generation (nb_salle+1, x, y-50, a, b-1)
        generation (nb_salle+1, x, y+50, a, b+1)
        generation (nb_salle+1, x+50, y, a+1, b)

    if (board[a-1][b], board[a][b+1], board[a][b-1]) == (1,1,1) and board[a+1][b] != 1 and nb_salle < 10:
        print("3 L B T")
        board [a-1] [b-1] = 2
        draw_cellR(x-50,y-50)
        board [a-1] [b+1] = 2
        draw_cellR(x-50,y+50)
        generation (nb_salle+1, x, y-50, a, b-1)
        generation (nb_salle+1, x, y+50, a, b+1)
        generation (nb_salle+1, x-50, y, a-1, b)

    if (board[a-1][b], board[a+1][b], board[a][b-1]) == (1,1,1) and board[a][b+1] != 1 and nb_salle < 10:
        print("3 L R T")
        board [a+1] [b-1] = 2
        draw_cellR(x+50,y-50)
        board [a-1] [b-1] = 2
        draw_cellR(x-50,y-50)
        generation (nb_salle+1, x, y-50, a, b-1)
        generation (nb_salle+1, x-50, y, a-1, b)
        generation (nb_salle+1, x+50, y, a+1, b)

    if (board[a-1][b], board[a][b+1], board[a+1][b]) == (1,1,1) and board[a][b-1] != 1 and nb_salle < 10:
        print("3 L B R")
        board [a+1] [b+1] = 2
        draw_cellR(x+50,y+50)
        board [a-1] [b+1] = 2
        draw_cellR(x-50,y+50)
        generation (nb_salle+1, x-50, y, a-1, b)
        generation (nb_salle+1, x, y+50, a, b+1)
        generation (nb_salle+1, x+50, y, a+1, b)

    elif nb_salle < 10:
        print("autres")
        print(x)
        print(y)
        print(a)
        print(b)
        generation (nb_salle, x, y, a, b)



     

            
