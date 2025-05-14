# 🎮 Endless Runner – Tugas Pengembangan Gim TI 2025

**Vallery Pulungan – 225150701111026**  

Proyek ini merupakan implementasi dari game 2D Endless Runner sederhana yang dikembangkan menggunakan Unity sebagai bagian dari tugas mata kuliah **Pengembangan Gim TI 2025**.
Sebuah game 2D endless runner sederhana yang dikembangkan dengan Unity. Pemain bergerak otomatis dan harus menghindari rintangan sebanyak mungkin. Game ini dilengkapi dengan animasi, efek parallax, pergerakan tilemap yang looping, dan peningkatan kesulitan secara dinamis.

---

## 🚀 Fitur Utama

- 🧍‍♂️ **Pergerakan Karakter**: Gerakan kiri-kanan, lompat, dan animasi dinamis menggunakan `Animator`.
- 🌄 **Parallax Background**: Efek kedalaman visual melalui pergerakan latar belakang.
- 🧱 **Tilemap Looping**: Tile platform bergerak dan mengulang terus-menerus.
- 🚧 **Obstacle Spawning**: Rintangan muncul secara acak dan menjadi lebih cepat seiring waktu.
- 🧠 **Game Manager & Event**: Mengelola status game (`isPlaying`, `GameOver`) dan event `onPlay`.
- 💥 **Collision Detection**: Permainan berakhir saat pemain menabrak obstacle.
- 🎼 **Musik Latar & UI**: Musik loop dan antarmuka klasik yang mendukung tema petualangan.

---

## 🎮 Kontrol

| Tombol         | Aksi                   |
|----------------|------------------------|
| ← / →          | Gerak ke kiri / kanan  |
| Space          | Lompat                 |

---

## 📁 Struktur Folder (Ringkasan)

```
Assets/
├── Scenes/
│ └── SampleScene.unity
├── Settings/
├── TextMesh Pro/
├── aset/
│ ├── background/
│ ├── music/
│ ├── obstacle/
│ ├── player/
│ ├── FreeDemo.png
├── script/
│ ├── Data.cs
│ ├── GameManager.cs
│ ├── Parallax.cs
│ ├── PlayerCollision.cs
│ ├── PlayerMovement.cs
│ ├── SpawnerScript.cs
│ ├── Tile.cs
│ └── UIManager.cs
├── Obstaclebox.prefab
├── Obstaclebox 1.prefab
├── DefaultVolumeProfile.asset
├── InputSystem_Actions.inputactions
├── UniversalRenderPipelineGlobalSettings.asset

Packages/
├── manifest.json
├── packages-lock.json

ProjectSettings/
```

## 🎨 Referensi Aset
Aset visual dan audio yang digunakan dalam proyek ini berasal dari sumber gratis dan legal:

- [Music Loop Bundle – Tallbeard](https://tallbeard.itch.io/music-loop-bundle)
- [UI Medieval – Toffeecraft](https://toffeecraft.itch.io/ui-user-interface-medieval)
- [Oak Woods – Brullov](https://brullov.itch.io/oak-woods)
- [Nature Platformer Tileset – RottingPixels](https://rottingpixels.itch.io/nature-platformer-tileset)
- [Pixel Adventure 1 – PixelFrog](https://pixelfrog-assets.itch.io/pixel-adventure-1)

## 🎬 Cuplikan Gameplay

Berikut beberapa cuplikan dari game **Endless Runner**:

### ▶️ Start Screen
Tampilan awal game sebelum permainan dimulai.

![Screenshot (2312)](https://github.com/user-attachments/assets/1bb3a2dc-731f-460a-b623-3cf90577c2d9)


---

### 💀 Game Over Screen
Tampilan saat pemain menabrak rintangan dan permainan selesai.

![Screenshot (2311)](https://github.com/user-attachments/assets/61ab6ab0-31b8-4032-8f94-fb09312153ab)


---

### 🎥 Video Gameplay
Cuplikan singkat gameplay selama permainan berlangsung.
[Endless Runner](https://drive.google.com/file/d/1Ci5qwd9ifr7kYVz0P1C0Z41WButXTkbJ/view?usp=sharing)




