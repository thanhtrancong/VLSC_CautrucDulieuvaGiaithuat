// Timer variables
const TOTAL_TIME = 5 * 60; // 5 minutes in seconds
const STORAGE_KEY = 'geometricMergeGameTimeUsed';
let timeRemaining = TOTAL_TIME;
let timerInterval = null;
let gameStartTime = null;

// Game variables
const shapeSequence = [
  { name: 'Circle', sides: Infinity, color: '#836FFF' },
  { name: 'Triangle', sides: 3, color: '#FF6868' },
  { name: 'Square', sides: 4, color: '#80B3FF' },
  { name: 'Pentagon', sides: 5, color: '#A5158C' },
  { name: 'Hexagon', sides: 6, color: '#FFBB64' },
  { name: 'Heptagon', sides: 7, color: '#FF9E9E' },
  { name: 'Octagon', sides: 8, color: '#F3CCFF' },
  { name: 'Nonagon', sides: 9, color: '#35A29F' },
  { name: 'Decagon', sides: 10, color: '#B771E5' },
  { name: '5-Point Star', sides: 5, color: '#B6F500', isStar: true }
];

let world;
let canvas;
let ctx;
let bodies = [];
let nextShapeIndex = 0;
let score = 0;
let isGameOver = false;
let animationId;

const playAreaWidth = 250;
const playAreaHeight = 250;
const pixelsPerMeter = 50;

let dropX = playAreaWidth / 2;

const backgroundMusic = new Audio('https://soniacoco.github.io/AudioRecordings/BackgroundMusic.mp3');
backgroundMusic.loop = true;
backgroundMusic.volume = 0.5;

// Initialize time remaining from localStorage immediately
function initializeTimeRemaining() {
  try {
    const usedTime = parseInt(localStorage.getItem(STORAGE_KEY) || '0', 10);
    timeRemaining = Math.max(0, TOTAL_TIME - usedTime);
    console.log(`Loaded from localStorage: ${usedTime} seconds used, ${timeRemaining} remaining`);
  } catch (e) {
    console.error('Error reading localStorage:', e);
    timeRemaining = TOTAL_TIME;
  }
}

// Check if time is already used up
function checkTimeRemaining() {
  initializeTimeRemaining();

  if (timeRemaining <= 0) {
    document.getElementById('modal').style.display = 'none';
    document.getElementById('times-up-modal').style.display = 'block';
    return false;
  }

  const minutes = Math.floor(timeRemaining / 60);
  const seconds = timeRemaining % 60;
  document.getElementById('time-remaining-text').textContent =
    `You have ${minutes}:${seconds.toString().padStart(2, '0')} of playtime remaining`;

  return true;
}

function updateTimerDisplay() {
  const minutes = Math.floor(timeRemaining / 60);
  const seconds = timeRemaining % 60;
  const timerElement = document.getElementById('timer');
  timerElement.textContent = `${minutes}:${seconds.toString().padStart(2, '0')}`;

  if (timeRemaining <= 60) {
    timerElement.classList.add('warning');
  }
}

function startTimer() {
  gameStartTime = Date.now();

  timerInterval = setInterval(() => {
    timeRemaining--;
    updateTimerDisplay();

    const usedTime = TOTAL_TIME - timeRemaining;
    try {
      localStorage.setItem(STORAGE_KEY, usedTime.toString());
      console.log(`Saved to localStorage: ${usedTime} seconds used`);
    } catch (e) {
      console.error('Error saving to localStorage:', e);
    }

    if (timeRemaining <= 0) {
      endGameTimeUp();
    }
  }, 1000);
}

function stopTimer() {
  if (timerInterval) {
    clearInterval(timerInterval);
    timerInterval = null;
  }
}

function endGameTimeUp() {
  stopTimer();
  isGameOver = true;
  cancelAnimationFrame(animationId);
  backgroundMusic.pause();

  document.getElementById('ui').style.display = 'none';
  document.getElementById('game-container').style.display = 'none';
  document.getElementById('volume-control').style.display = 'none';
  document.getElementById('times-up-modal').style.display = 'block';
}

function createStarVertices(numPoints, outerRadius, innerRadius) {
  const vertices = [];
  const angleStep = (Math.PI * 2) / (numPoints * 2);

  for (let i = 0; i < numPoints * 2; i++) {
    const radius = i % 2 === 0 ? outerRadius : innerRadius;
    const angle = i * angleStep - Math.PI / 2;
    vertices.push([
      radius * Math.cos(angle),
      radius * Math.sin(angle)
    ]);
  }
  return vertices;
}

function createPolygonVertices(sides, radius) {
  const vertices = [];
  const angleStep = (Math.PI * 2) / sides;

  for (let i = 0; i < sides; i++) {
    const angle = i * angleStep - Math.PI / 2;
    vertices.push([
      radius * Math.cos(angle),
      radius * Math.sin(angle)
    ]);
  }
  return vertices;
}

function init() {
  world = new p2.World({
    gravity: [0, 9.82]
  });

  world.defaultContactMaterial.restitution = 0;
  world.defaultContactMaterial.friction = 0.8;

  canvas = document.getElementById('gameCanvas');
  canvas.width = playAreaWidth;
  canvas.height = playAreaHeight;
  ctx = canvas.getContext('2d');

  const groundBody = new p2.Body({
    position: [playAreaWidth / 2 / pixelsPerMeter, (playAreaHeight - 10) / pixelsPerMeter],
    type: p2.Body.STATIC
  });
  const groundShape = new p2.Rectangle(playAreaWidth / pixelsPerMeter, 20 / pixelsPerMeter);
  groundBody.addShape(groundShape);
  world.addBody(groundBody);

  const leftWallBody = new p2.Body({
    position: [-10 / pixelsPerMeter, playAreaHeight / 2 / pixelsPerMeter],
    type: p2.Body.STATIC
  });
  const leftWallShape = new p2.Rectangle(20 / pixelsPerMeter, playAreaHeight / pixelsPerMeter);
  leftWallBody.addShape(leftWallShape);
  world.addBody(leftWallBody);

  const rightWallBody = new p2.Body({
    position: [(playAreaWidth + 10) / pixelsPerMeter, playAreaHeight / 2 / pixelsPerMeter],
    type: p2.Body.STATIC
  });
  const rightWallShape = new p2.Rectangle(20 / pixelsPerMeter, playAreaHeight / pixelsPerMeter);
  rightWallBody.addShape(rightWallShape);
  world.addBody(rightWallBody);

  world.on('beginContact', handleCollision);

  setupLineCanvas();
  gameLoop();
  spawnNextShape();
}

function createShape(type, x, y) {
  const size = (30 + shapeSequence.indexOf(type) * 5) * 0.5;
  const radius = size / 2 / pixelsPerMeter;

  const body = new p2.Body({
    mass: 1,
    position: [x / pixelsPerMeter, y / pixelsPerMeter]
  });

  let shape;
  if (type.isStar) {
    const vertices = createStarVertices(5, radius, radius * 0.4);
    shape = new p2.Convex(vertices);
  } else if (type.sides === Infinity) {
    shape = new p2.Circle(radius);
  } else {
    const vertices = createPolygonVertices(type.sides, radius);
    shape = new p2.Convex(vertices);
  }

  const material = new p2.Material();
  shape.material = material;

  body.addShape(shape);
  body.shapeType = type.name;
  body.color = type.color;
  body.isStar = type.isStar || false;
  body.size = size;

  const contactMaterial = new p2.ContactMaterial(material, world.defaultMaterial, {
    friction: 0.8,
    restitution: 0,
    stiffness: 1e7,
    relaxation: 3,
    frictionStiffness: 1e7,
    frictionRelaxation: 3
  });
  world.addContactMaterial(contactMaterial);

  world.addBody(body);
  bodies.push(body);
  return body;
}

function spawnNextShape() {
  if (isGameOver) {
    return;
  }

  const y = 50;
  const type = shapeSequence[nextShapeIndex];
  createShape(type, dropX, y);

  nextShapeIndex = Math.floor(Math.random() * 5);
  document.getElementById('next-shape').textContent = shapeSequence[nextShapeIndex].name;
}

function handleCollision(evt) {
  const bodyA = evt.bodyA;
  const bodyB = evt.bodyB;

  if (bodyA.type === p2.Body.STATIC || bodyB.type === p2.Body.STATIC) {
    return;
  }

  if (
    bodyA.shapeType &&
    bodyB.shapeType &&
    bodyA.shapeType === bodyB.shapeType &&
    bodyA !== bodyB &&
    !bodyA.merging &&
    !bodyB.merging
  ) {
    const currentIndex = shapeSequence.findIndex((shape) => shape.name === bodyA.shapeType);
    const nextShapeType = shapeSequence[currentIndex + 1];
    if (nextShapeType) {
      bodyA.merging = true;
      bodyB.merging = true;

      const newX = ((bodyA.position[0] + bodyB.position[0]) / 2) * pixelsPerMeter;
      const newY = ((bodyA.position[1] + bodyB.position[1]) / 2) * pixelsPerMeter;

      setTimeout(() => {
        world.removeBody(bodyA);
        world.removeBody(bodyB);
        bodies = bodies.filter((body) => body !== bodyA && body !== bodyB);

        createShape(nextShapeType, newX, newY);

        if (nextShapeType.isStar) {
          score += 1000000;
        } else {
          score += currentIndex + 1;
        }
        document.getElementById('score').textContent = score;
      }, 50);
    }
  }
}

function drawShape(body) {
  const x = body.position[0] * pixelsPerMeter;
  const y = body.position[1] * pixelsPerMeter;
  const angle = body.angle;

  ctx.save();
  ctx.translate(x, y);
  ctx.rotate(angle);
  ctx.fillStyle = body.color;

  if (body.isStar) {
    ctx.strokeStyle = 'gold';
    ctx.lineWidth = 2;
    ctx.shadowColor = body.color;
    ctx.shadowBlur = 10;
  }

  const shape = body.shapes[0];
  if (shape instanceof p2.Circle) {
    ctx.beginPath();
    ctx.arc(0, 0, shape.radius * pixelsPerMeter, 0, Math.PI * 2);
    ctx.fill();
  } else if (shape instanceof p2.Convex) {
    ctx.beginPath();
    const vertices = shape.vertices;
    if (vertices.length > 0) {
      ctx.moveTo(vertices[0][0] * pixelsPerMeter, vertices[0][1] * pixelsPerMeter);
      for (let i = 1; i < vertices.length; i++) {
        ctx.lineTo(vertices[i][0] * pixelsPerMeter, vertices[i][1] * pixelsPerMeter);
      }
      ctx.closePath();
      ctx.fill();
      if (body.isStar) {
        ctx.stroke();
      }
    }
  } else if (shape instanceof p2.Rectangle) {
    const w = shape.width * pixelsPerMeter;
    const h = shape.height * pixelsPerMeter;
    ctx.fillRect(-w / 2, -h / 2, w, h);
  }
  ctx.restore();
}

function gameLoop() {
  if (isGameOver) {
    return;
  }

  world.step(1 / 60);

  ctx.clearRect(0, 0, canvas.width, canvas.height);
  ctx.fillStyle = '#20252d';
  ctx.fillRect(0, 0, canvas.width, canvas.height);

  ctx.fillStyle = 'white';
  ctx.fillRect(0, playAreaHeight - 20, playAreaWidth, 20);

  bodies.forEach((body) => {
    drawShape(body);

    const y = body.position[1] * pixelsPerMeter;
    if (y < 0) {
      endGame();
    }
  });

  animationId = requestAnimationFrame(gameLoop);
}

function endGame() {
  isGameOver = true;
  stopTimer();
  cancelAnimationFrame(animationId);
  document.getElementById('game-over').style.display = 'block';
}

function restartGame() {
  if (timeRemaining <= 0) {
    endGameTimeUp();
    return;
  }

  isGameOver = false;
  score = 0;
  document.getElementById('score').textContent = score;
  document.getElementById('game-over').style.display = 'none';

  bodies.forEach((body) => world.removeBody(body));
  bodies = [];

  gameLoop();
  spawnNextShape();
}

function setupLineCanvas() {
  const lineCanvas = document.getElementById('lineCanvas');
  lineCanvas.width = playAreaWidth;
  lineCanvas.height = playAreaHeight;
  const lineCtx = lineCanvas.getContext('2d');

  document.addEventListener('mousemove', (event) => {
    const rect = lineCanvas.getBoundingClientRect();
    dropX = event.clientX - rect.left;

    lineCtx.clearRect(0, 0, lineCanvas.width, lineCanvas.height);
    lineCtx.beginPath();
    lineCtx.moveTo(dropX, 0);
    lineCtx.lineTo(dropX, playAreaHeight);
    lineCtx.strokeStyle = 'white';
    lineCtx.lineWidth = 2;
    lineCtx.stroke();
  });

  document.getElementById('game-container').addEventListener('click', (event) => {
    const rect = lineCanvas.getBoundingClientRect();
    const clickX = event.clientX - rect.left;
    const clickY = event.clientY - rect.top;

    if (clickX >= 0 && clickX <= playAreaWidth && clickY >= 0 && clickY <= playAreaHeight) {
      lineCtx.clearRect(0, 0, lineCanvas.width, lineCanvas.height);
      spawnNextShape();
    }
  });
}

function toggleDirections() {
  const directions = document.getElementById('directions');
  const button = document.getElementById('how-to-play-button');

  const isHidden = window.getComputedStyle(directions).display === 'none';
  directions.style.display = isHidden ? 'block' : 'none';
  button.textContent = isHidden ? 'Hide Directions' : 'How to Play';
}

function startGame() {
  if (!checkTimeRemaining()) {
    return;
  }

  document.getElementById('modal').style.display = 'none';
  document.getElementById('ui').style.display = 'block';
  document.getElementById('game-container').style.display = 'block';
  document.getElementById('volume-control').style.display = 'block';
  backgroundMusic.play().catch((e) => console.log('Audio autoplay blocked', e));

  updateTimerDisplay();
  startTimer();
  init();
}

const volumeSlider = document.getElementById('volume-slider');
volumeSlider.addEventListener('input', (event) => {
  backgroundMusic.volume = event.target.value;
});

document.getElementById('how-to-play-button').addEventListener('click', toggleDirections);
document.getElementById('start-button').addEventListener('click', startGame);
document.getElementById('restart-button').addEventListener('click', restartGame);

initializeTimeRemaining();
window.addEventListener('load', () => {
  checkTimeRemaining();
});
