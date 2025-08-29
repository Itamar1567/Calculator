import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LayoutComponent } from './layout.component/layout.component';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, LayoutComponent],
  template: '<app-layout> </app-layout> <router-outlet />',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Math-App');
}
