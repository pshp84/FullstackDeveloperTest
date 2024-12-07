import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
@Component({
  selector: 'app-confirmation-dialog',
  standalone: true,
  templateUrl: './confirmation-dialog.component.html',
  styleUrl: './confirmation-dialog.component.scss',
  imports: [MatDialogModule, MatButtonModule], // Import necessary Angular Material modules
})
export class ConfirmationDialogComponent {
  constructor(public dialogRef: MatDialogRef<ConfirmationDialogComponent>) {}

  onCancel(): void {
    this.dialogRef.close(false); // Close the dialog and pass "false"
  }

  onConfirm(): void {
    this.dialogRef.close(true); // Close the dialog and pass "true"
  }
}
