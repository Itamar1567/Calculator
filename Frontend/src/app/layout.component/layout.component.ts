import { Component } from '@angular/core';

@Component({
  standalone: true,
  selector: 'app-layout',
  imports: [],
  template: ` 

  <section class="layout">
    <ul class="layout-links">
      <li><img src="assets/images/favicon.png" alt="icon"/><li>
      <li>Home</li>
      <li>About</li>
      <li>Math</li>
    </ul> 
  </section>
  <section class="copyright">
    <p>copyright: Itamar1567 </p>
  </section>

  
    
  `,
  styleUrl: './layout.component.css'
})
export class LayoutComponent {

}
