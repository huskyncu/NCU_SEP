#include  <stdio.h>
#include  <unistd.h>
#include  <stdlib.h>
#include  <sys/types.h>
#include  <sys/ipc.h>
#include  <sys/sem.h>
#include "awk_sem.h"

main() {
  int semid ;

  semid = create_sem(".",'S',0);
  printf("(prog1-%d) we are going to sleep until the semaphore is increased\n",getpid());

  P(semid);

  printf("(prog1-%d) is waked up\n", getpid());

    
  //destroy_sem(semid);
  //printf("(prog1) semaphore removed\n");

}
      
    
