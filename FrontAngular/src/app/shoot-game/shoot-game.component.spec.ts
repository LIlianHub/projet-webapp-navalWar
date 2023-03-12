import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShootGameComponent } from './shoot-game.component';

describe('ShootGameComponent', () => {
  let component: ShootGameComponent;
  let fixture: ComponentFixture<ShootGameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShootGameComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShootGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
