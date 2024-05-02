import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authAdminGuard: CanActivateFn = (route, state) => {
  const userStr = localStorage.getItem('user');
  if (userStr !== null) {
    const user = JSON.parse(userStr);
    if (user && (user.roleId === 1 || user.roleId === 3)) {
      return true;
    }
  }
  
  inject(Router).navigate(['login']);
  return false;
};


