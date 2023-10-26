#include  <stdio.h>
#include  <unistd.h>
#include  <stdlib.h>
#include  <sys/types.h>
#include  <sys/ipc.h>
#include  <sys/sem.h>
#include "awk_sem.h"

main() {
  int semid ;
   
  semid = get_sem(".",'S');

  printf("\n\n(prog2) the NO. of blocked processes of the semphore is [%d]\n",
          get_blocked_no(semid));
  printf("(prog2) current semaphore value is [%d]\n", get_sem_val(semid));
  
  // WE ARE GOING TO INCREASE THE SEMAPHORE
  printf("(prog2) we are going to increase the semaphore\n");
  
  V(semid);

  printf("(prog2) quit !\n");
}
      
    
